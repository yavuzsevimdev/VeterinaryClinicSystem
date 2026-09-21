using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherAsync(string city);
    }
}
