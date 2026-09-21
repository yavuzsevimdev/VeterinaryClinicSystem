using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Weather;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _CustomerDashboardWeatherComponentPartial : ViewComponent
    {
        private readonly IWeatherService _weatherService;

        public _CustomerDashboardWeatherComponentPartial(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weather = await _weatherService.GetWeatherAsync("İstanbul");
            return View(weather);
        }
    }
}
