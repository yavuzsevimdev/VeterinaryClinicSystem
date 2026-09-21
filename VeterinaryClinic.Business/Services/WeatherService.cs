using Microsoft.Extensions.Configuration;
using System.Text.Json;
using VeterinaryClinic.Business.Dtos.WeatherDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherInfo> GetWeatherAsync(string city)
        {
            var apiKey = _configuration["OpenWeatherMap:ApiKey"];
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=tr";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var weatherData = JsonSerializer.Deserialize<WeatherApiResponseDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var weatherInfo = new WeatherInfo
            {
                City = weatherData.Name,
                Temperature = weatherData.Main.Temp,
                Description = weatherData.Weather[0].Description,
                Date = DateTime.Now
            };


            return weatherInfo;
        }
    }
}
