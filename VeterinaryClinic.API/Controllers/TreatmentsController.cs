using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.Business.Dtos.TreatmentDtos;
using VeterinaryClinic.Business.Services;

namespace VeterinaryClinic.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public TreatmentsController(ITreatmentService treatmentService, IAppointmentService appointmentService, IAnimalService animalService)
        {
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
            _animalService = animalService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _treatmentService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var value = await _treatmentService.GetByIdAsync(id);
            if (value == null)
                return NotFound();

            var appointment = await _appointmentService.GetByIdAsync(value.AppointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            return Ok(value);
        }

        [HttpGet("my-treatments")]
        public async Task<IActionResult> GetMyTreatments()
        {
            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _treatmentService.GetByOwnerIdAsync(ownerId);
            return Ok(values);
        }

        [HttpGet("total-cost")]
        public async Task<IActionResult> TotalCost(int appointmentId)
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

            var totalCost = await _treatmentService.TotalCostAsync(appointmentId);
            return Ok(totalCost);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTreatmentDto dto)
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

            await _treatmentService.AddAsync(dto);
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTreatmentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var treatment = await _treatmentService.GetByIdAsync(dto.Id);
            if (treatment == null)
                return NotFound();

            var appointment = await _appointmentService.GetByIdAsync(treatment.AppointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if (!User.IsInRole("Manager") && treatment.AppointmentId != dto.AppointmentId)
                return Forbid();

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            await _treatmentService.UpdateAsync(dto);
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var treatment = await _treatmentService.GetByIdAsync(id);
            if (treatment == null)
                return NotFound();

            var appointment = await _appointmentService.GetByIdAsync(treatment.AppointmentId);
            if (appointment == null)
                return NotFound();

            var animal = await _animalService.GetByIdAsync(appointment.AnimalId);
            if (animal == null)
                return NotFound();

            if(!User.IsInRole("Manager") && animal.OwnerId != userId)
                return Forbid();

            await _treatmentService.DeleteAsync(id);
            return Ok("Silme işlemi başarılı.");
        }
    }
}
