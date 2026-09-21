using Newtonsoft.Json;
using System.Net.Http.Headers;
using VeterinaryClinic.UI.Dtos.Treatment;

namespace VeterinaryClinic.UI.Services.Treatment
{
    public class TreatmentService : ITreatmentService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TreatmentService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<TreatmentDto>> GetMyTreatmentsAsync()
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/treatments/my-treatments";

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var treatments = JsonConvert.DeserializeObject<List<TreatmentDto>>(json);

            return treatments;
        }
    }
}
