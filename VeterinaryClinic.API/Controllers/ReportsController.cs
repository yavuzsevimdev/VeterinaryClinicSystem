using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Business.Services;

namespace VeterinaryClinic.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyReport(DateTime date)
        {
            var report = await _reportService.GetDailyAppointmentReportAsync(date);
            return Ok(report);
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetMonthlyReport(DateTime date)
        {
            var report = await _reportService.GetMonthlyAppointmentReportAsync(date);
            return Ok(report);
        }

        [HttpGet("financial")]
        public async Task<IActionResult> GetFinancialReport(DateTime startDate, DateTime endDate)
        {
            var report = await _reportService.GetFinancialReportAsync(startDate, endDate);
            return Ok(report);
        }

        [HttpGet("animal-treatment-history")]
        public async Task<IActionResult> GetAnimalTreatmentHistory(int animalId)
        {
            var report = await _reportService.GetAnimalTreatmentHistoryAsync(animalId);
            return Ok(report);
        }
    }
}
