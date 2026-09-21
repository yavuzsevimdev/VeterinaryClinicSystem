using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Dashboard;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _CustomerDashboardUpcomingAppointmentComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;

        public _CustomerDashboardUpcomingAppointmentComponentPartial(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var upcomingAppointment = await _appointmentService.GetUpcomingAppointment();
            return View(upcomingAppointment.OrderBy(x => x.Date).FirstOrDefault());
        }
    }
}
