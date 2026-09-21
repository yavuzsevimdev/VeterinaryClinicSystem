using VeterinaryClinic.Business.Dtos.ReportDtos;

namespace VeterinaryClinic.Business.Services
{
    public interface IReportService
    {
        Task<DailyAppointmentReportDto> GetDailyAppointmentReportAsync(DateTime date);
        Task<MonthlyAppointmentReportDto> GetMonthlyAppointmentReportAsync(DateTime date);
        Task<FinancialReportDto> GetFinancialReportAsync(DateTime startDate, DateTime endDate);
        Task<List<AnimalTreatmentHistoryDto>> GetAnimalTreatmentHistoryAsync(int animalId);
    }
}
