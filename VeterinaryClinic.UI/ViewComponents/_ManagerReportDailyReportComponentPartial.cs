using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerReportDailyReportComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPaymentService _paymentService;

        public _ManagerReportDailyReportComponentPartial(IAppointmentService appointmentService, IPaymentService paymentService)
        {
            _appointmentService = appointmentService;
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var todayAppointment = (await _appointmentService.GetAllAppointmentsAsync()).Where(x => x.Date.Day == DateTime.Today.Day).ToList();
            ViewBag.TodayApppointmentCount = todayAppointment.Count();
            ViewBag.CompletedApppointmentCount = todayAppointment.Count(x => x.Status == "Completed");
            ViewBag.ScheduledApppointmentCount = todayAppointment.Count(x => x.Status == "Scheduled");

            var todayPayments = (await _paymentService.GetAllPaymentsAsync()).Where(x => x.PaymentDate.Day == DateTime.Today.Day).ToList();   
            ViewBag.TotalAmountPaid = todayPayments.Sum(x => x.AmountPaid);

            return View();
        }
    }
}
