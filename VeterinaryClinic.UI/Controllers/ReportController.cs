using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Report;

namespace VeterinaryClinic.UI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DownloadDailyReportPdf()
        {
            var pdf = await _reportService.DownloadDailyReportPdfAsync();
            if (pdf == null)
                return NotFound("Günlük rapor PDF'i oluşturulamadı.");

            return File(
                pdf,
                "application/pdf",
                $"Gunluk-Randevu-Raporu-{DateTime.Today:dd-MM-yyyy}.pdf"
            );
        }

        [HttpPost]
        public async Task<IActionResult> SendDailyReportPdf()
        {
            var result = await _reportService.SendDailyReportPdfAsync();

            if (!result)
            {
                TempData["ReportError"] = "Günlük rapor email olarak gönderilemedi.";
                return RedirectToAction("Index");
            }

            TempData["ReportSuccess"] = "Günlük rapor başarıyla email adresinize gönderildi.";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadMonthlyReportPdf()
        {
            var pdf = await _reportService.DownloadMonthlyReportPdfAsync();

            if (pdf == null)
                return NotFound("Aylık rapor PDF'i oluşturulamadı.");

            return File(
                pdf,
                "application/pdf",
                $"Aylik-Randevu-Raporu-{DateTime.Today:MM-yyyy}.pdf"
            );
        }


        [HttpPost]
        public async Task<IActionResult> SendMonthlyReportPdf()
        {
            var result = await _reportService.SendMonthlyReportPdfAsync();

            if (!result)
            {
                TempData["ReportError"] = "Aylık rapor email olarak gönderilemedi.";
                return RedirectToAction("Index");
            }

            TempData["ReportSuccess"] = "Aylık rapor başarıyla email adresinize gönderildi.";

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DownloadFinancialReportPdf()
        {
            var pdf = await _reportService.DownloadFinancialReportPdfAsync();
            if (pdf == null)
                return NotFound("Finansal rapor PDF'i oluşturulamadı.");

            return File(
                pdf,
                "application/pdf",
                $"Finansal-Rapor-{DateTime.Today:dd-MM-yyyy}.pdf"
            );
        }

        [HttpPost]
        public async Task<IActionResult> SendFinancialReportPdf()
        {
            var result = await _reportService.SendFinancialReportPdfAsync();

            if (!result)
            {
                TempData["ReportError"] =
                    "Finansal rapor email olarak gönderilemedi.";

                return RedirectToAction("Index");
            }

            TempData["ReportSuccess"] = "Finansal rapor başarıyla email adresinize gönderildi.";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadAnimalTreatmentReportPdf()
        {
            var pdf = await _reportService.DownloadAnimalTreatmentReportPdfAsync();
            if (pdf == null)
                return NotFound("Hayvan tedavi raporu PDF'i oluşturulamadı.");

            return File(
                pdf,
                "application/pdf",
                $"Hayvan-Tedavi-Raporu-{DateTime.Today:dd-MM-yyyy}.pdf"
            );
        }


        [HttpPost]
        public async Task<IActionResult> SendAnimalTreatmentReportPdf()
        {
            var result = await _reportService.SendAnimalTreatmentReportPdfAsync();

            if (!result)
            {
                TempData["ReportError"] = "Hayvan tedavi raporu email olarak gönderilemedi.";

                return RedirectToAction("Index");
            }

            TempData["ReportSuccess"] = "Hayvan tedavi raporu başarıyla email adresinize gönderildi.";

            return RedirectToAction("Index");
        }
    }
}
