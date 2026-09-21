using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Payment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _PaymentIndexStatisticsComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;

        public _PaymentIndexStatisticsComponentPartial(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetMyPaymentsAsync();
            ViewBag.TotalAmountPaid = payments.Sum(p => p.AmountPaid);
            ViewBag.TotalDebt = await _paymentService.GetTotalDebtAsync();
            ViewBag.TotalNumberOfPayments = payments.Count;
            ViewBag.AveragePaymentAmount = payments.Count > 0 ? payments.Average(p => p.AmountPaid) : 0;
            return View();
        }
    }
}
