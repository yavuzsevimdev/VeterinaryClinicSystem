using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Dashboard;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _ManagerDashboardStatisticsComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var statistics = await _dashboardService.GetManagerStatisticsAsync();
            return View(statistics);
        }
    }
}
