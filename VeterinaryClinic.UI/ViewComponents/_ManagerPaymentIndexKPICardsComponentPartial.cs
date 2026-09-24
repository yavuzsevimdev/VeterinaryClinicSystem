using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentIndexKPICardsComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly IAppointmentService _appointmentService;
        private readonly ITreatmentService _treatmentService;

        public _ManagerPaymentIndexKPICardsComponentPartial(IPaymentService paymentService, IAppointmentService appointmentService, ITreatmentService treatmentService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var treatments = await _treatmentService.GetAllTreatmentsAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();

            var prevMonthPayments = payments.Where(x => x.PaymentDate.Date.Month == DateTime.Today.Month - 1).ToList();
            var thisMonthPayments = payments.Where(x => x.PaymentDate.Date.Month == DateTime.Today.Month).ToList();
            var prevDayPayments = payments.Where(x => x.PaymentDate.Date.Day == DateTime.Today.Day - 1).ToList();
            var todayPayments = payments.Where(x => x.PaymentDate.Date.Day == DateTime.Today.Day).ToList();

            var unpaid = new List<AppointmentDto>();
            foreach (var item in appointments)
            {
                var value = (treatments.Where(x => x.AppointmentId == item.Id).Sum(x => x.Cost) - payments.Where(x => x.AppointmentId == item.Id).Sum(x => x.AmountPaid));
                if (value > 0)
                {
                    unpaid.Add(item);
                }
            }

            ViewBag.TotalAmountPaid = payments.Sum(x => x.AmountPaid);
            ViewBag.TotalAmountPaidChangeRate = (thisMonthPayments.Sum(x => x.AmountPaid) * 100) / (prevMonthPayments.Sum(x => x.AmountPaid) == 0 ? 1 : (prevMonthPayments.Sum(x => x.AmountPaid)));
            ViewBag.ThisMonthTotalAmountPaid = thisMonthPayments.Sum(x => x.AmountPaid);
            ViewBag.ThisMonthPaymentCount = thisMonthPayments.Count();
            ViewBag.TotalTodayAmountPaid = todayPayments.Sum(x => x.AmountPaid);
            ViewBag.DailyAmountPaidChangeRate = prevDayPayments.Sum(x => x.AmountPaid) == 0 ? 0 : ((todayPayments.Sum(x => x.AmountPaid) - prevDayPayments.Sum(x => x.AmountPaid)) / prevDayPayments.Sum(x => x.AmountPaid)) * 100;
            ViewBag.TotalDebt = treatments.Sum(x => x.Cost) - payments.Sum(x => x.AmountPaid);
            ViewBag.UnpaidCount = unpaid.Count();
            return View();
        }
    }
}
