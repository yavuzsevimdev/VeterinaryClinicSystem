using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Weather;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerDashboardWeatherComponentPartial : ViewComponent
    {
        private readonly IWeatherService _weatherService;

        public _ManagerDashboardWeatherComponentPartial(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _weatherService.GetWeatherAsync("İstanbul");
            return View(value);
        }
    }
}
