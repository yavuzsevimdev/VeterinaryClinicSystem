using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Dashboard;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _CustomerDashboardStatisticsComponentPartial : ViewComponent
    {

        private readonly IDashboardService _dashboardService;

        public _CustomerDashboardStatisticsComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var statistics = await _dashboardService.GetStatisticsForDashboard();
            return View(statistics);
        }
    }
}
