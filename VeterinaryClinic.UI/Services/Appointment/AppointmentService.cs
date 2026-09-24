using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Dtos.Dashboard;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAnimalService _animalService;

        public AppointmentService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IAnimalService animalService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _animalService = animalService;
        }

        public async Task<bool> CancelAppointmentAsync(int appointmentId)
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments/{appointmentId}/cancel";
            var response = await _httpClient.PutAsync(url, null);
            if (!response.IsSuccessStatusCode)
                return false;
            return true;
        }

        public async Task<string> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments";

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return null;

            return "Ekleme işlemi başarılı";
        }

        public async Task<byte[]> DownloadPdfAsync(int appointmentId)
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments/{appointmentId}/pdf";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json);
            return appointments;
        }

        public async Task<List<AppointmentDto>> GetAnimalAppointmentsAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments/my-appointments";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json);

            return appointments.Where(x => x.AnimalId == id).ToList();
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments/{id}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var appointment = JsonConvert.DeserializeObject<AppointmentDto>(json);
            return appointment;
        }

        public async Task<List<AppointmentDto>> GetMyAppointmentsAsync()
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments/my-appointments";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json);

            return appointments;
        }

        public async Task<List<UpcomingAppointmentDto>> GetUpcomingAppointment()
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments/my-appointments";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json);
            var upcomingAppointments = appointments.Where(x => x.Status == "Scheduled" && x.Date >= DateTime.Today && x.Date <= DateTime.Today.AddDays(7))
                                                  .OrderBy(x => x.Date)
                                                  .ThenBy(x => x.Time)
                                                  .ToList();
            if (upcomingAppointments == null)
                return null;

            var values = new List<UpcomingAppointmentDto>();
            foreach (var item in upcomingAppointments)
            {
                var animal = await _animalService.GetAnimalByIdAsync(item.AnimalId);
                values.Add(new UpcomingAppointmentDto
                {
                    AppointmentId = item.Id,
                    AnimalName = animal.Name,
                    Date = item.Date,
                    Time = item.Time,
                    Status = item.Status,
                    Notes = item.Notes,
                    ImageUrl = animal.ImageUrl,
                    Breed = animal.Breed,
                    Species = animal.Species
                });
            }

            return values;
        }

        public async Task<bool> UpdateAppointmentAsync(AppointmentDto dto)
        {
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments";
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }
    }
}
