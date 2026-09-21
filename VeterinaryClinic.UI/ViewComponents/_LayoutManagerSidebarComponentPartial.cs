using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Dashboard;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _LayoutManagerSidebarComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _LayoutManagerSidebarComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var todayAppointments = await _dashboardService.GetManagerTodayAppointmentsAsync();
            ViewBag.TodayAppointments = todayAppointments.Count();
            return View();
        }
    }
}
