using Newtonsoft.Json;
using System.Net.Http.Headers;
using VeterinaryClinic.UI.Dtos.User;

namespace VeterinaryClinic.UI.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto> GetMyProfileAsync()
        {
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/users/me";

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(json);

            return user;
        }
    }
}
