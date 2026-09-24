using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Payment;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;

namespace VeterinaryClinic.UI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IAppointmentService _appointmentService;

        public PaymentController(IPaymentService paymentService, IAppointmentService appointmentService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
        }

        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Manager")]
        [HttpGet]
        public async Task<IActionResult> MakePayment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            return View(appointment);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> MakePayment(CreatePaymentDto dto)
        {
            await _paymentService.CreatePaymentAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
