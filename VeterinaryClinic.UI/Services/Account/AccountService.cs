using Newtonsoft.Json;
using System.Text;
using VeterinaryClinic.UI.Dtos.Account;

namespace VeterinaryClinic.UI.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public AccountService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/Users/login";
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);
            if (!response.IsSuccessStatusCode)
                return null;

            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/Users/register";
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(url, stringContent);
            if (!responseMessage.IsSuccessStatusCode)
                return false;

            return true;
        }
    }
}
