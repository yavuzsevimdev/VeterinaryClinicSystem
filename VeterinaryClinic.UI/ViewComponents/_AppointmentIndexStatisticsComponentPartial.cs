using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentIndexStatisticsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;

        public _AppointmentIndexStatisticsComponentPartial(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appointments = await _appointmentService.GetMyAppointmentsAsync();
            ViewBag.TotalAppointment = appointments.Count();

            var upcomingAppointments = await _appointmentService.GetUpcomingAppointment();
            ViewBag.UpcomingAppointments = upcomingAppointments.Count();

            var completedAppointments = appointments.Where(x => x.Status == "Completed").ToList();
            ViewBag.CompletedAppointments = completedAppointments.Count();

            var cancelledAppointments = appointments.Where(x => x.Status == "Cancelled").ToList();
            ViewBag.CancelledAppointments = cancelledAppointments.Count();

            return View();
        }
    }
}
