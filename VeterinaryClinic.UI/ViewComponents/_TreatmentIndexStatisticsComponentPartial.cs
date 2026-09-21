using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _TreatmentIndexStatisticsComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public _TreatmentIndexStatisticsComponentPartial(ITreatmentService treatmentService, IAnimalService animalService, IAppointmentService appointmentService)
        {
            _treatmentService = treatmentService;
            _animalService = animalService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var treatments = await _treatmentService.GetMyTreatmentsAsync();
            ViewBag.TotalTreatment = treatments.Count();
            ViewBag.TotalTreatmentThisYear = treatments.Count(x => x.Date.Value.Year == DateTime.Now.Year);

            var appointments = new List<AppointmentDto>();
            var animals = new List<AnimalDto>();
            foreach (var item in treatments)
            {
                appointments.Add(await _appointmentService.GetAppointmentByIdAsync(item.AppointmentId));
            }
            foreach(var item in appointments)
            {
                animals.Add(await _animalService.GetAnimalByIdAsync(item.AnimalId));
            }
            ViewBag.TotalTreatedAnimal = animals.DistinctBy(x => x.Id).Count();

            ViewBag.TotalCost = treatments.Sum(x => x.Cost);
            ViewBag.TotalCostThisYear = treatments.Where(x => x.Date.Value.Year == DateTime.Now.Year).Sum(x => x.Cost);

            var lastTreatment = treatments.OrderByDescending(x => x.Date).FirstOrDefault();
            var lastTreatmentAppointment = await _appointmentService.GetAppointmentByIdAsync(lastTreatment.AppointmentId);
            var lastTreatmentAnimal = await _animalService.GetAnimalByIdAsync(lastTreatmentAppointment.AnimalId);
            ViewBag.LastTreatmentDate = lastTreatment.Date;
            ViewBag.LastTreatmentAnimal = lastTreatmentAnimal.Name;
            ViewBag.LastTreatmentType = lastTreatment.TreatmentType;

            return View();
        }
    }
}
