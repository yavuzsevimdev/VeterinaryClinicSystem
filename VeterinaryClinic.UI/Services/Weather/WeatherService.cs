using Newtonsoft.Json;
using System.Net.Http.Headers;
using VeterinaryClinic.UI.Dtos.Weather;

namespace VeterinaryClinic.UI.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeatherService(IConfiguration configuration, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<WeatherDto> GetWeatherAsync(string city)
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/Weather?city={city}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var weather = JsonConvert.DeserializeObject<WeatherDto>(json);

            return weather;
        }
    }
}
