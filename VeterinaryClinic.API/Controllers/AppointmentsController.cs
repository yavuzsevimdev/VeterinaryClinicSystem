using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.API.Services.Email;
using VeterinaryClinic.API.Services.Pdf;
using VeterinaryClinic.Business.Dtos.AppointmentDtos;
using VeterinaryClinic.Business.Services;

namespace VeterinaryClinic.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly ILogger<AppointmentsController> _logger;
        private readonly IPdfService _pdfService;
        private readonly IEmailService _emailService;

        public AppointmentsController(IAppointmentService appointmentService, IAnimalService animalService, ILogger<AppointmentsController> logger, IPdfService pdfService, IEmailService emailService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
            _logger = logger;
            _pdfService = pdfService;
            _emailService = emailService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _appointmentService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _appointmentService.GetByIdAsync(id);

            if (value == null)
                return NotFound();

            var ownerId = await _appointmentService.GetOwnerIdByAppointmentIdAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (User.IsInRole("Manager") || userId == ownerId)
                return Ok(value);

            return Forbid();
        }

        [HttpGet("my-appointments")]
        public async Task<IActionResult> GetMyAppointments()
        {
            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _appointmentService.GetByOwnerIdAsync(ownerId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAppointmentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var animal = await _animalService.GetByIdAsync(dto.AnimalId);

            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && userId != animal.OwnerId)
                return Forbid();

            await _appointmentService.AddAsync(dto);
            _logger.LogInformation("Appointment created. AnimalId: {AnimalId}", dto.AnimalId);
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var appointment = await _appointmentService.GetByIdAsync(dto.Id);

            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);

            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            if (!User.IsInRole("Manager") && appointment.AnimalId != dto.AnimalId)
                return Forbid();

            if (!User.IsInRole("Manager") && appointment.Status != dto.Status)
                return Forbid();

            await _appointmentService.UpdateAsync(dto);
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            await _appointmentService.DeleteAsync(id);
            return Ok("Silme işlemi başarılı.");
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            await _appointmentService.CancelAsync(id);

            return Ok("Randevu iptal edildi.");
        }

        [HttpPost("complete")]
        public async Task<IActionResult> CompleteAppointment(CompleteAppointmentDto dto)
        {
            await _appointmentService.CompleteAppointmentAsync(dto);
            return Ok("Randevu başarıyla tamamlandı.");
        }

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GeneratePdf(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _appointmentService.GetAppointmentWithDetailsAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
            {
                return Forbid();
            }

            var treatment = appointment.Treatments?.FirstOrDefault();
            var payment = appointment.Payments?.FirstOrDefault();

            var pdf = _pdfService.CreateAppointmentReport(
                appointment.Id,
                animal.Name,
                appointment.Date,
                appointment.Time,
                appointment.Status,
                appointment.Notes,
                treatment?.TreatmentType ?? "No treatment",
                treatment?.Notes ?? "No treatment notes",
                treatment?.Cost ?? 0,
                payment?.AmountPaid ?? 0,
                payment?.PaymentMethod ?? "No payment");

            _logger.LogInformation(
                "Appointment PDF created. AppointmentId: {AppointmentId}",
                appointment.Id);

            return File(
                pdf,
                "application/pdf",
                $"appointment-{appointment.Id}.pdf");
        }

        [HttpPost("{id}/send-pdf")]
        public async Task<IActionResult> SendAppointmentPdf(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _appointmentService.GetAppointmentWithDetailsAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
            {
                return Forbid();
            }

            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Kullanıcı email adresi bulunamadı.");
            }

            var treatment = appointment.Treatments?.FirstOrDefault();
            var payment = appointment.Payments?.FirstOrDefault();

            var pdf = _pdfService.CreateAppointmentReport(
                appointment.Id,
                animal.Name,
                appointment.Date,
                appointment.Time,
                appointment.Status,
                appointment.Notes,
                treatment?.TreatmentType ?? "No treatment",
                treatment?.Notes ?? "No treatment notes",
                treatment?.Cost ?? 0,
                payment?.AmountPaid ?? 0,
                payment?.PaymentMethod ?? "No payment");

            await _emailService.SendEmailAsync(email, "Veterinary Clinic - Randevu Raporu", $"{animal.Name} için randevu raporunuz Ek'te gönderildi.", pdf, $"appointment-{appointment.Id}.pdf");

            _logger.LogInformation(
                "Appointment PDF sent by email. AppointmentId: {AppointmentId}, Email: {Email}",
                appointment.Id,
                email);

            return Ok("PDF raporu email adresinize gönderildi.");
        }
    }
}
