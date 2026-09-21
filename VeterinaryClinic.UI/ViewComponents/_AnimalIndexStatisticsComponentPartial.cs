using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalIndexStatisticsComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;
        private readonly IAppointmentService _appointmentService;
        private readonly ITreatmentService _treatmentService;

        public _AnimalIndexStatisticsComponentPartial(IAnimalService animalService, IAppointmentService appointmentService, ITreatmentService treatmentService)
        {
            _animalService = animalService;
            _appointmentService = appointmentService;
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetMyAnimalsAsync();
            ViewBag.TotalAnimal = animals.Count();

            var appointments = await _appointmentService.GetUpcomingAppointment();
            ViewBag.UpcomingAppointmenCount = appointments.Count();

            var treatments = await _treatmentService.GetMyTreatmentsAsync();
            ViewBag.TreatmentHistory = treatments.Count();

            return View();
        }
    }
}
