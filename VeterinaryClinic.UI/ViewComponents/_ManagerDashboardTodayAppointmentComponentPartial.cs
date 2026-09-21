using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Dashboard;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerDashboardTodayAppointmentComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _ManagerDashboardTodayAppointmentComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetManagerTodayAppointmentsAsync();
            return View(values);
        }
    }
}
