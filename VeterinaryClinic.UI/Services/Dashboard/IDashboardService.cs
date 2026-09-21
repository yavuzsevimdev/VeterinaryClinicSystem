using VeterinaryClinic.UI.Dtos.Dashboard;

namespace VeterinaryClinic.UI.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardStatisticsDto> GetStatisticsForDashboard();
        Task<ManagerDashboardStatisticsDto> GetManagerStatisticsAsync();
        Task<List<ManagerDashboardAppointmentDto>> GetManagerTodayAppointmentsAsync();
        Task<List<ManagerDashboardRecentTreatmentsDto>> GetManagerRecentTreatmentsAsync();
        Task<ManagerDashboardFinancialOverviewDto> GetManagerFinancialOverviewAsync();
    }
}
