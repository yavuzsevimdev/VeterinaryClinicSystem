using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Dtos.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _TreatmentIndexTreatmentListComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public _TreatmentIndexTreatmentListComponentPartial(ITreatmentService treatmentService, IAppointmentService appointmentService, IAnimalService animalService)
        {
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var treatments = new List<TreatmentDto>();
            if (User.IsInRole("Manager"))
            {
                treatments = await _treatmentService.GetAllTreatmentsAsync();
            }
            if (User.IsInRole("Customer"))
            {
                treatments = await _treatmentService.GetMyTreatmentsAsync();
            }
            if (treatments == null)
                return null;

            var appointments = await _appointmentService.GetMyAppointmentsAsync();
            var animals = await _animalService.GetMyAnimalsAsync();
            var treatmentList = new List<TreatmentListDto>();
            foreach (var item in treatments)
            {
                var appointment = appointments.FirstOrDefault(a => a.Id == item.AppointmentId);
                var animal = animals.FirstOrDefault(a => a.Id == appointment.AnimalId);
                treatmentList.Add(new TreatmentListDto
                {
                    Animal = animal,
                    Appointment = appointment,
                    AppointmentId = item.AppointmentId,
                    Cost = item.Cost,
                    Date = item.Date,
                    Id = item.Id,
                    Notes = item.Notes,
                    TreatmentType = item.TreatmentType
                });
            }

            ViewBag.TotalTreatmentCount = treatmentList.Count();

            return View(treatmentList);
        }
    }
}
