using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentDetailAppliedTreatmentsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ITreatmentService _treatmentService;

        public _AppointmentDetailAppliedTreatmentsComponentPartial(IAppointmentService appointmentService, ITreatmentService treatmentService)
        {
            _appointmentService = appointmentService;
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return View(null);

            var treatments = await _treatmentService.GetMyTreatmentsAsync();
            treatments = treatments.Where(x => x.AppointmentId == appointment.Id).OrderBy(x => x.Date).ToList();

            ViewBag.TotalCost = treatments.Sum(x => x.Cost);
            return View(treatments);
        }
    }
}
