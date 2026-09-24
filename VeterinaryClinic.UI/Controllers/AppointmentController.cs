using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public AppointmentController(IAppointmentService appointmentService, IAnimalService animalService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto dto)
        {
            await _appointmentService.CreateAppointmentAsync(dto);
            return RedirectToAction("Index");
        }
         
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return NotFound();

            if(User.IsInRole("Customer"))
            {
                ViewBag.Animals = await _animalService.GetMyAnimalsAsync();
            }
            if (User.IsInRole("Manager"))
            {
                ViewBag.AppointmentId = id;
            }
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppointmentDto dto)
        {
            var result = await _appointmentService.UpdateAppointmentAsync(dto);
            if (!result)
            {
                ViewBag.Animals = await _animalService.GetMyAnimalsAsync();
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.AppointmentId = id;
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            return View(appointment);
        }

        public async Task<IActionResult> Pdf(int id)
        {
            var pdf = await _appointmentService.DownloadPdfAsync(id);

            if (pdf == null)
                return NotFound();

            return File(
                pdf,
                "application/pdf",
                $"appointment-{id}.pdf");
        }

        public async Task<IActionResult> Cancel(int id)
        {
            await _appointmentService.CancelAppointmentAsync(id);
            return RedirectToAction("Index");
        }
    }
}
