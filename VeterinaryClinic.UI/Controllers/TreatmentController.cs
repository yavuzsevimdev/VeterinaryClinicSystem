using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Treatment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public TreatmentController(ITreatmentService treatmentService, IAppointmentService appointmentService, IAnimalService animalService, IUserService userService)
        {
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var treatments = new List<TreatmentDto>();
            var values = new List<TreatmentListDto>();

            if (User.IsInRole("Manager"))
            {
                treatments = (await _treatmentService.GetAllTreatmentsAsync()).OrderByDescending(x => x.Date).ToList();
                foreach (var item in treatments)
                {
                    var appointment = await _appointmentService.GetAppointmentByIdAsync(item.AppointmentId);
                    var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);
                    var owner = (await _userService.GetAllUsersAsync()).FirstOrDefault(x => x.Id == animal.OwnerId);
                    values.Add(new TreatmentListDto
                    {
                        Animal = animal,
                        Appointment = appointment,
                        Owner = owner,
                        AppointmentId = item.AppointmentId,
                        Cost = item.Cost,
                        Date = item.Date,
                        Id = item.Id,
                        Notes = item.Notes,
                        TreatmentType = item.TreatmentType
                    });
                }
                return View(values);

            }
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.TreatmentId = id;
            return View();
        }

        [Authorize(Roles ="Manager")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var owners = await _userService.GetAllCustomersAsync();
            var animals = await _animalService.GetAllAnimalsAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var treatments = await _treatmentService.GetAllTreatmentsAsync();

            ViewBag.Owners = owners;
            ViewBag.Animals = animals;
            ViewBag.Appointments = appointments
                .Where(x => x.Status == "Scheduled")
                .ToList();
            ViewBag.TreatmentTypes = treatments
                .Where(x => !string.IsNullOrWhiteSpace(x.TreatmentType))
                .Select(x => x.TreatmentType)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTreatmentDto dto)
        {
            if (dto == null)
                return View("Error");

            await _treatmentService.CreateTreatmentAsync(dto);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var treatment = (await _treatmentService.GetAllTreatmentsAsync()).FirstOrDefault(x => x.Id == id);
            if(treatment == null)
                return RedirectToAction("Index");

            var owners = await _userService.GetAllCustomersAsync();
            var animals = await _animalService.GetAllAnimalsAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var treatments = await _treatmentService.GetAllTreatmentsAsync();

            var appointment = await _appointmentService.GetAppointmentByIdAsync(treatment.AppointmentId);
            var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);

            ViewBag.SelectedOwnerId = animal.OwnerId;
            ViewBag.SelectedAnimalId = animal.Id;
            ViewBag.SelectedAppointmentId = appointment.Id;

            ViewBag.Owners = owners;
            ViewBag.Animals = animals;
            ViewBag.Appointments = appointments
                .Where(x => x.Status == "Scheduled")
                .ToList();
            ViewBag.TreatmentTypes = treatments
                .Where(x => !string.IsNullOrWhiteSpace(x.TreatmentType))
                .Select(x => x.TreatmentType)
                .Distinct()
                .OrderBy(x => x)
                .ToList();


            return View(treatment);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Update(TreatmentDto dto)
        {
            var result = await _treatmentService.UpdateTreatmentAsync(dto);
            if (!result)
                return View(dto);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _treatmentService.DeleteTreatmentAsync(id);
            return RedirectToAction("Index");
        }
    }
}
