using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentTreatmentsInfosComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;

        public _ManagerAppointmentTreatmentsInfosComponentPartial(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto appointment)
        {
            var treatments = (await _treatmentService.GetAllTreatmentsAsync()).Where(x => x.AppointmentId == appointment.Id).ToList();
            ViewBag.Treatments = treatments;
            return View(appointment);
        }
    }
}
