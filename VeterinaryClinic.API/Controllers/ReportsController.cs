using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.API.Services.Email;
using VeterinaryClinic.API.Services.Pdf;
using VeterinaryClinic.Business.Services;

namespace VeterinaryClinic.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IPdfService _pdfService;
        private readonly IEmailService _emailService;

        public ReportsController(IReportService reportService, IPdfService pdfService, IEmailService emailService)
        {
            _reportService = reportService;
            _pdfService = pdfService;
            _emailService = emailService;
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyReport(DateTime date)
        {
            var report = await _reportService.GetDailyAppointmentReportAsync(date);
            return Ok(report);
        }

        [HttpGet("daily/pdf")]
        public async Task<IActionResult> DownloadDailyPdf()
        {
            var report = await _reportService.GetDailyAppointmentReportAsync(DateTime.Today.Date);

            if (report == null)
            {
                return NotFound("Günlük rapor bulunamadı.");
            }

            var pdf = await _pdfService.GenerateDailyReportPdfAsync(report);

            return File(
                pdf,
                "application/pdf",
                $"Gunluk-Randevu-Raporu-{report.Date:dd-MM-yyyy}.pdf"
            );
        }

        [HttpPost("daily/send-pdf")]
        public async Task<IActionResult> SendDailyReportPdf()
        {
            var report = await _reportService.GetDailyAppointmentReportAsync(DateTime.Today.Date);

            if (report == null)
                return NotFound("Günlük rapor bulunamadı.");

            var pdf = await _pdfService.GenerateDailyReportPdfAsync(report);

            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
                return BadRequest("Manager email adresi bulunamadı.");

            await _emailService.SendEmailAsync(
                email,
                "Günlük Randevu Raporu",
                "Günlük randevu raporunuz ekte yer almaktadır.",
                pdf,
                $"Gunluk-Randevu-Raporu-{report.Date:dd-MM-yyyy}.pdf"
            );

            return Ok("Günlük rapor email olarak gönderildi.");
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetMonthlyReport(DateTime date)
        {
            var report = await _reportService.GetMonthlyAppointmentReportAsync(date);
            return Ok(report);
        }

        [HttpGet("monthly/pdf")]
        public async Task<IActionResult> GetMonthlyReportPdf()
        {
            var report = await _reportService.GetMonthlyAppointmentReportAsync(DateTime.Today);

            if (report == null)
                return NotFound("Aylık rapor bulunamadı.");

            var pdf = await _pdfService.GenerateMonthlyReportPdfAsync(report);

            return File(
                pdf,
                "application/pdf",
                $"Aylik-Randevu-Raporu-{report.Date:MM-yyyy}.pdf"
            );
        }

        [HttpPost("monthly/send-pdf")]
        public async Task<IActionResult> SendMonthlyReportPdf()
        {
            var report = await _reportService.GetMonthlyAppointmentReportAsync(DateTime.Today);
            if (report == null)
                return NotFound("Aylık rapor bulunamadı.");

            var pdf = await _pdfService.GenerateMonthlyReportPdfAsync(report);
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email))
                return BadRequest("Manager email adresi bulunamadı.");

            await _emailService.SendEmailAsync(
                email,
                "Aylık Randevu Raporu",
                "Aylık randevu raporunuz ekte yer almaktadır.",
                pdf,
                $"Aylik-Randevu-Raporu-{report.Date:MM-yyyy}.pdf"
            );

            return Ok("Aylık rapor email olarak gönderildi.");
        }

        [HttpGet("financial")]
        public async Task<IActionResult> GetFinancialReport(DateTime startDate, DateTime endDate)
        {
            var report = await _reportService.GetFinancialReportAsync(startDate, endDate);
            return Ok(report);
        }

        [HttpGet("financial/pdf")]
        public async Task<IActionResult> GetFinancialReportPdf()
        {
            var startDate = DateTime.Today.AddDays(-30);
            var endDate = DateTime.Today;
            var report = await _reportService.GetFinancialReportAsync(startDate, endDate);
            if (report == null)
                return NotFound("Finansal rapor bulunamadı.");

            var pdf = await _pdfService.GenerateFinancialReportPdfAsync(report);
            return File(
                pdf,
                "application/pdf",
                $"Finansal-Rapor-{startDate:dd-MM-yyyy}-{endDate:dd-MM-yyyy}.pdf"
            );
        }

        [HttpPost("financial/send-pdf")]
        public async Task<IActionResult> SendFinancialReportPdf()
        {
            var startDate = DateTime.Today.AddDays(-30);
            var endDate = DateTime.Today;
            var report = await _reportService.GetFinancialReportAsync(startDate, endDate);

            if (report == null)
                return NotFound("Finansal rapor bulunamadı.");

            var pdf = await _pdfService.GenerateFinancialReportPdfAsync(report);
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email))
                return BadRequest("Manager email adresi bulunamadı.");

            await _emailService.SendEmailAsync(
                email,
                "Finansal Rapor",
                "Finansal raporunuz ekte yer almaktadır.",
                pdf,
                $"Finansal-Rapor-{startDate:dd-MM-yyyy}-{endDate:dd-MM-yyyy}.pdf"
            );

            return Ok("Finansal rapor email olarak gönderildi.");
        }

        [HttpGet("animal-treatment-history")]
        public async Task<IActionResult> GetAnimalTreatmentHistory(int animalId)
        {
            var report = await _reportService.GetAnimalTreatmentHistoryAsync(animalId);
            return Ok(report);
        }

        [HttpGet("animal-treatment/pdf")]
        public async Task<IActionResult> GetAnimalTreatmentReportPdf()
        {
            var treatments = await _reportService.GetAllAnimalTreatmentHistoryAsync();
            if (treatments == null || !treatments.Any())
                return NotFound("Hayvan tedavi raporu bulunamadı.");

            var pdf = await _pdfService.GenerateAnimalTreatmentReportPdfAsync(treatments);
            return File(
                pdf,
                "application/pdf",
                $"Hayvan-Tedavi-Raporu-{DateTime.Today:dd-MM-yyyy}.pdf"
            );
        }

        [HttpPost("animal-treatment/send-pdf")]
        public async Task<IActionResult> SendAnimalTreatmentReportPdf()
        {
            var treatments = await _reportService.GetAllAnimalTreatmentHistoryAsync();
            if (treatments == null || !treatments.Any())
                return NotFound("Hayvan tedavi raporu bulunamadı.");

            var pdf = await _pdfService.GenerateAnimalTreatmentReportPdfAsync(treatments);
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
                return BadRequest("Manager email adresi bulunamadı.");

            await _emailService.SendEmailAsync(
                email,
                "Hayvan Tedavi Raporu",
                "Hayvan tedavi raporunuz ekte yer almaktadır.",
                pdf,
                $"Hayvan-Tedavi-Raporu-{DateTime.Today:dd-MM-yyyy}.pdf"
            );

            return Ok("Hayvan tedavi raporu email olarak gönderildi.");
        }
    }
}
