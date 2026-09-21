using Newtonsoft.Json;
using System.Net.Http.Headers;
using VeterinaryClinic.UI.Dtos.Payment;

namespace VeterinaryClinic.UI.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<PaymentDto>> GetMyPaymentsAsync()
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/payments/my-payments";

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var payments = JsonConvert.DeserializeObject<List<PaymentDto>>(json);

            return payments;
        }

        public async Task<decimal> GetTotalDebtAsync()
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/payments/my-debt";

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return 0;

            var json = await response.Content.ReadAsStringAsync();
            var totalDebt = JsonConvert.DeserializeObject<decimal>(json);

            return totalDebt;
        }
    }
}
