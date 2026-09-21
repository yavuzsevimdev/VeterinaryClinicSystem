using VeterinaryClinic.UI.Dtos.Weather;

namespace VeterinaryClinic.UI.Services.Weather
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(string city);
    }
}
