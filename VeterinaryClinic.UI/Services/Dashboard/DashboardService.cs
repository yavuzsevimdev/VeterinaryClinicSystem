using Newtonsoft.Json;
using System.Net.Http.Headers;
using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Dtos.Dashboard;
using VeterinaryClinic.UI.Dtos.Payment;
using VeterinaryClinic.UI.Dtos.Treatment;
using VeterinaryClinic.UI.Dtos.Report;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAnimalService _animalService;
        private readonly IAppointmentService _appointmentService;

        public DashboardService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IAnimalService animalService, IAppointmentService appointmentService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _animalService = animalService;
            _appointmentService = appointmentService;
        }

        public async Task<ManagerDashboardStatisticsDto> GetManagerStatisticsAsync()
        {
            int totalAnimals = 0;
            int todayAppointments = 0;
            int scheduledRemainingToday = 0;
            int completedTreatments = 0;
            decimal outstandingDebt = 0;

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/animals";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var animals = JsonConvert.DeserializeObject<List<AnimalDto>>(json);
            totalAnimals = animals.Count();


            url = $"{baseUrl}/api/appointments";
            response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json);
            todayAppointments = appointments.Count(x => x.Date.Date == DateTime.Today);
            scheduledRemainingToday = appointments.Count(x => x.Date.Date == DateTime.Today && x.Time > DateTime.Now.TimeOfDay && x.Status == "Scheduled");


            url = $"{baseUrl}/api/treatments";
            response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            json = await response.Content.ReadAsStringAsync();
            var treatments = JsonConvert.DeserializeObject<List<TreatmentDto>>(json);
            completedTreatments = treatments.Join(appointments, t => t.AppointmentId, a => a.Id, (t, a) => a).Count(x => x.Status == "Completed");


            url = $"{baseUrl}/api/payments";
            response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            json = await response.Content.ReadAsStringAsync();
            var payments = JsonConvert.DeserializeObject<List<PaymentDto>>(json);
            outstandingDebt = treatments.Sum(x => x.Cost) - payments.Sum(x => x.AmountPaid);


            return new ManagerDashboardStatisticsDto
            {
                TotalAnimals = totalAnimals,
                TodayAppointments = todayAppointments,
                ScheduledRemainingToday = scheduledRemainingToday,
                CompletedTreatments = completedTreatments,
                OutstandingDebt = outstandingDebt
            };
        }

        public async Task<List<ManagerDashboardAppointmentDto>> GetManagerTodayAppointmentsAsync()
        {
            var todayAppointments = new List<ManagerDashboardAppointmentDto>();

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/appointments";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json);
            appointments = appointments.Where(x => x.Date.Date == DateTime.Today).ToList();
            var animals = new List<AnimalDto>();
            for(int i = 0; i < appointments.Count; i++)
            {
                animals.Add(await _animalService.GetAnimalByIdAsync(appointments[i].AnimalId));
                todayAppointments.Add(new ManagerDashboardAppointmentDto
                {
                    AnimalId = appointments[i].AnimalId,
                    AnimalName = animals[i].Name,
                    AppointmentId = appointments[i].Id,
                    Date = appointments[i].Date,
                    Time = appointments[i].Time,
                    Notes = appointments[i].Notes,
                    Status = appointments[i].Status
                });
            }

            return todayAppointments;
        }

        public async Task<DashboardStatisticsDto> GetStatisticsForDashboard()
        {
            int animalsCount = 0;
            int upcomingAppointmentsCount = 0;
            int treatmentsCount = 0;
            decimal outstandingBalance = 0;

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/animals/my-animals";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var animals = JsonConvert.DeserializeObject<List<AnimalDto>>(json);
            animalsCount = animals.Count();


            url = $"{baseUrl}/api/appointments/my-appointments";
            response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json);
            upcomingAppointmentsCount = appointments.Count(x => x.Status == "Scheduled" && x.Date >= DateTime.Today);


            url = $"{baseUrl}/api/treatments/my-treatments";
            response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            json = await response.Content.ReadAsStringAsync();
            var treatments = JsonConvert.DeserializeObject<List<TreatmentDto>>(json);
            treatmentsCount = treatments.Count();


            url = $"{baseUrl}/api/payments/my-debt";
            response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            json = await response.Content.ReadAsStringAsync();
            var debt = JsonConvert.DeserializeObject<decimal>(json);
            outstandingBalance = debt;


            return new DashboardStatisticsDto
            {
                AnimalsCount = animalsCount,
                UpcomingAppointmentsCount = upcomingAppointmentsCount,
                TreatmentsCount = treatmentsCount,
                OutstandingBalance = outstandingBalance
            };
        }


        public async Task<List<ManagerDashboardRecentTreatmentsDto>> GetManagerRecentTreatmentsAsync()
        {
            var recentTreatments = new List<ManagerDashboardRecentTreatmentsDto>();

            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/treatments";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var treatments = JsonConvert.DeserializeObject<List<TreatmentDto>>(json);
            var appointments = new AppointmentDto();
            var animals = new AnimalDto();
            for (int i = 0; i < treatments.Count; i++)
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(treatments[i].AppointmentId);
                var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);
                recentTreatments.Add(new ManagerDashboardRecentTreatmentsDto
                {
                    Id = treatments[i].Id,
                    AnimalName = animal.Name,
                    AppointmentId = treatments[i].AppointmentId,
                    TreatmentType = treatments[i].TreatmentType,
                    Cost = treatments[i].Cost,
                    Notes = treatments[i].Notes
                });
            }

            return recentTreatments;
        }

        public async Task<ManagerDashboardFinancialOverviewDto> GetManagerFinancialOverviewAsync()
        {
            var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); ;
            var endDate = DateTime.Now;
            var token = _httpContextAccessor.HttpContext.User.FindFirst("AccessToken")?.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var url = $"{baseUrl}/api/reports/financial?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var financialOverview = JsonConvert.DeserializeObject<FinancialReportDto>(json);
            if (financialOverview == null)
                return null;

            double paidPercentage = financialOverview.TotalTreatmentCost > 0
            ? (double)(financialOverview.TotalPaid / financialOverview.TotalTreatmentCost * 100)
            : 0;

            double debtPercentage = 100 - paidPercentage;

            return new ManagerDashboardFinancialOverviewDto
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalTreatmentCost = financialOverview.TotalTreatmentCost,
                TotalPaid = financialOverview.TotalPaid,
                TotalDebt = financialOverview.TotalDebt,
                PaidPercentage = paidPercentage,
                DebtPercentage = debtPercentage
            };
        }
    }
}
