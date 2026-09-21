using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _TreatmenDetailTreatmentSummaryComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;

        public _TreatmenDetailTreatmentSummaryComponentPartial(ITreatmentService treatmentService, IAppointmentService appointmentService)
        {
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var treatments = await _treatmentService.GetMyTreatmentsAsync();
            var treatment = treatments.FirstOrDefault(x => x.Id == id);
            var appointment = await _appointmentService.GetAppointmentByIdAsync(treatment.AppointmentId);
            ViewBag.Status = appointment.Status;
            return View(treatment);
        }
    }
}
