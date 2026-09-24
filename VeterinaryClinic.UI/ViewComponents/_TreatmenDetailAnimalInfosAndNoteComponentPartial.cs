using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Treatment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _TreatmenDetailAnimalInfosAndNoteComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAnimalService _animalService;
        private readonly IAppointmentService _appointmentService;

        public _TreatmenDetailAnimalInfosAndNoteComponentPartial(ITreatmentService treatmentService, IAnimalService animalService, IAppointmentService appointmentService)
        {
            _treatmentService = treatmentService;
            _animalService = animalService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var treatments = new List<TreatmentDto>();
            if(User.IsInRole("Manager"))
            {
                treatments = await _treatmentService.GetAllTreatmentsAsync();
            }
            if (User.IsInRole("Customer"))
            {
                treatments = await _treatmentService.GetMyTreatmentsAsync();
            }
            var treatment = treatments.FirstOrDefault(x => x.Id == id);
            if (treatment == null)
                return Content("Tedavi bulunamadı.");
            var appointment = await _appointmentService.GetAppointmentByIdAsync(treatment.AppointmentId);
            var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);
            ViewBag.Note = treatment.Notes;
            return View(animal);
        }
    }
}
