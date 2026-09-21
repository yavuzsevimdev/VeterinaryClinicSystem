using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.Business.Dtos.PaymentDtos;
using VeterinaryClinic.Business.Services;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public PaymentsController(IPaymentService paymentService, IAppointmentService appointmentService, IAnimalService animalService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
            _animalService = animalService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _paymentService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null)
                return NotFound();

            var appointment = await _appointmentService.GetByIdAsync(payment.AppointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            return Ok(payment);
        }

        [HttpGet("my-payments")]
        public async Task<IActionResult> GetMyPayments()
        {
            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _paymentService.GetByOwnerIdAsync(ownerId);
            return Ok(values);
        }

        [HttpGet("debt")]
        public async Task<IActionResult> GetMyDebt(int appointmentId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _appointmentService.GetByIdAsync(appointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            var debt = await _paymentService.GetDebtAsync(appointmentId);
            return Ok(debt);
        }

        [HttpGet("my-debt")]
        public async Task<IActionResult> GetTotalDebtByOwnerIdAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var totalDebt = await _paymentService.GetTotalDebtByOwnerIdAsync(userId);
            return Ok(totalDebt);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePaymentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _appointmentService.GetByIdAsync(dto.AppointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            await _paymentService.AddAsync(dto);
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePaymentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var payment = await _paymentService.GetByIdAsync(dto.Id);
            if (payment == null)
                return NotFound();

            var appointment = await _appointmentService.GetByIdAsync(payment.AppointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && payment.AppointmentId != dto.AppointmentId)
                return Forbid();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            await _paymentService.UpdateAsync(dto);
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null)
                return NotFound();

            var appointment = await _appointmentService.GetByIdAsync(payment.AppointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            await _paymentService.DeleteAsync(id);
            return Ok("Silme işlemi başarılı.");
        }
    }
}
