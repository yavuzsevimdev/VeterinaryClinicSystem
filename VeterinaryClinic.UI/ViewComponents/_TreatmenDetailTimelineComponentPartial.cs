using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Treatment;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _TreatmenDetailTimelineComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ITreatmentService _treatmentService;

        public _TreatmenDetailTimelineComponentPartial(IAppointmentService appointmentService, ITreatmentService treatmentService)
        {
            _appointmentService = appointmentService;
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
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
            var activeTreatment = treatments.FirstOrDefault(t => t.Id == id);
            if (activeTreatment == null)
            {
                return View("Error");
            }

            var appointment = await _appointmentService.GetAppointmentByIdAsync(activeTreatment.AppointmentId);
            if (appointment == null)
            {
                return View("Error");
            }
            var values = treatments.Where(x => x.AppointmentId == appointment.Id).OrderBy(x => x.Date).ToList();
            ViewBag.StartDate = values[0].Date.Value.ToString("dd.MM.yyyy");
            ViewBag.StartTime = values[0].Date.Value.ToString("HH:mm");

            ViewBag.EndDate = values[values.Count - 1].Date.Value.ToString("dd.MM.yyyy");
            ViewBag.EndTime = values[values.Count - 1].Date.Value.ToString("HH:mm");

            ViewBag.CurrentTreatmentId = id;
            return View(values);
        }
    }
}
