using VeterinaryClinic.Business.Dtos.ReportDtos;

namespace VeterinaryClinic.API.Services.Pdf
{
    public interface IPdfService
    {
        byte[] CreateAppointmentReport(
            int appointmentId,
            string animalName,
            DateTime appointmentDate,
            TimeSpan appointmentTime,
            string status,
            string notes,
            string treatmentType,
            string treatmentNotes,
            decimal treatmentCost,
            decimal paymentAmount,
            string paymentMethod);

        Task<byte[]> GenerateDailyReportPdfAsync(DailyAppointmentReportDto report);
        Task<byte[]> GenerateMonthlyReportPdfAsync(MonthlyAppointmentReportDto report);
        Task<byte[]> GenerateFinancialReportPdfAsync(FinancialReportDto report);
        Task<byte[]> GenerateAnimalTreatmentReportPdfAsync(List<AnimalTreatmentHistoryDto> treatments);
    }
}
