using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.Business.Dtos.AnimalDtos;
using VeterinaryClinic.Business.Services;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        private readonly IAppointmentService _appointmentService;
        private readonly ITreatmentService _treatmentService;
        private readonly UserManager<User> _userManager;

        public AnimalsController(IAnimalService animalService, IAppointmentService appointmentService, ITreatmentService treatmentService, UserManager<User> userManager)
        {
            _animalService = animalService;
            _appointmentService = appointmentService;
            _treatmentService = treatmentService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _animalService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("my-animals")]
        public async Task<IActionResult> GetMyAnimals()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _animalService.GetByOwnerIdAsync(userId);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);

            if(animal == null)
            {
                return NotFound();
            }

            if (User.FindFirstValue(ClaimTypes.NameIdentifier) == animal.OwnerId || User.IsInRole("Manager"))
            {
                return Ok(animal);
            }

            return Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAnimalDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Manager") && dto.OwnerId != userId)
            {
                return Forbid();
            }

            await _animalService.AddAsync(dto);
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnimalDto dto)
        {
            var animal = await _animalService.GetByIdAsync(dto.Id);

            if (animal == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.IsInRole("Manager") && animal.OwnerId != userId)
            {
                return Forbid();
            }

            if (!User.IsInRole("Manager") && dto.OwnerId != userId)
            {
                return Forbid();
            }

            await _animalService.UpdateAsync(dto);
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Manager") || User.FindFirstValue(ClaimTypes.NameIdentifier) == animal.OwnerId)
            {
                await _animalService.DeleteAsync(id);
                return Ok("Silme işlemi başarılı.");
            }

            return Forbid();
        }

        [HttpGet("{id}/appointments")]
        public async Task<IActionResult> GetMyAnimalAppointment(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Manager") || User.FindFirstValue(ClaimTypes.NameIdentifier) == animal.OwnerId)
            {
                var values = await _appointmentService.GetByAnimalIdAsync(id);
                return Ok(values);
            }

            return Forbid();
        }

        [HttpGet("{id}/treatments")]
        public async Task<IActionResult> GetMyAnimalTreatments(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (User.IsInRole("Manager") || animal.OwnerId == userId)
            {
                var values = await _treatmentService.GetByAnimalIdAsync(id);
                return Ok(values);
            }

            return Forbid();
        }
    }
}
