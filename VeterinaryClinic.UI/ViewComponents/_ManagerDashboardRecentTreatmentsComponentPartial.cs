using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Dashboard;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerDashboardRecentTreatmentsComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _ManagerDashboardRecentTreatmentsComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetManagerRecentTreatmentsAsync();
            return View(values.OrderByDescending(x => x.Id).Take(4).ToList());
        }
    }
}
