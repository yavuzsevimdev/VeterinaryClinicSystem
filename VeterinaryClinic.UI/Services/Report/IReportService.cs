namespace VeterinaryClinic.UI.Services.Report
{
    public interface IReportService
    {
        Task<byte[]> DownloadDailyReportPdfAsync();
        Task<byte[]> DownloadMonthlyReportPdfAsync();
        Task<byte[]> DownloadFinancialReportPdfAsync();
        Task<byte[]> DownloadAnimalTreatmentReportPdfAsync();
        Task<bool> SendDailyReportPdfAsync();
        Task<bool> SendMonthlyReportPdfAsync();
        Task<bool> SendFinancialReportPdfAsync();
        Task<bool> SendAnimalTreatmentReportPdfAsync();
    }
}
