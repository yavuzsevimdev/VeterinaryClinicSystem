using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using VeterinaryClinic.Entities;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentDetailTimelineComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;

        public _AppointmentDetailTimelineComponentPartial(ITreatmentService treatmentService, IAppointmentService appointmentService)
        {
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return View(null);

            var treatments = await _treatmentService.GetMyTreatmentsAsync();
            treatments = treatments.Where(x => x.AppointmentId == appointment.Id).OrderBy(x => x.Date).ToList();

            var values = new AppointmentDetailTimelineDto();
            values.Treatments = treatments;
            values.Status = appointment.Status;
            values.StartTime = appointment.Date + appointment.Time;
            values.EndTime = treatments.Where(x => x.Date.HasValue).OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefault();
            return View(values);
        }
    }
}
