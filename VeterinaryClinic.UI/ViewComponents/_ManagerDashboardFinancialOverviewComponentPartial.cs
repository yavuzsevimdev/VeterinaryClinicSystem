using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Dashboard;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerDashboardFinancialOverviewComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _ManagerDashboardFinancialOverviewComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _dashboardService.GetManagerFinancialOverviewAsync();
            return View(value);
        }
    }
}
