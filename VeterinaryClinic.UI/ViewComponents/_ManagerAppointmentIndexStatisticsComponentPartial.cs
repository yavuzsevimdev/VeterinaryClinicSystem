using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentIndexStatisticsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;

        public _ManagerAppointmentIndexStatisticsComponentPartial(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();

            ViewBag.TodayAppointmentCount = appointments.Count(x => x.Date.Day == DateTime.Now.Day);
            ViewBag.UpcomingAppointmentCount = appointments.Where(x => x.Status == "Scheduled" && x.Date >= DateTime.Today)
                                                  .OrderBy(x => x.Date)
                                                  .ThenBy(x => x.Time)
                                                  .Count();
            ViewBag.CompletedAppointmentCount = appointments.Count(x => x.Status == "Completed" && x.Date.Month == DateTime.Now.Month);
            ViewBag.CancelledAppointmentCount = appointments.Count(x => x.Status == "Cancelled" && x.Date.Month == DateTime.Now.Month);
            return View();
        }
    }
}
