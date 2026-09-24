using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Payment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentIndexMonthlyTrendComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;

        public _ManagerPaymentIndexMonthlyTrendComponentPartial(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();

            var paymentMonth1 = payments.Where(x => x.PaymentDate.Year == DateTime.Today.AddMonths(-5).Year 
                                                && x.PaymentDate.Date.Month == (DateTime.Today.AddMonths(-5)).Month).ToList();
            var paymentMonth2 = payments.Where(x => x.PaymentDate.Year == DateTime.Today.AddMonths(-4).Year
                                                && x.PaymentDate.Date.Month == (DateTime.Today.AddMonths(-4)).Month).ToList();
            var paymentMonth3 = payments.Where(x => x.PaymentDate.Year == DateTime.Today.AddMonths(-3).Year
                                                && x.PaymentDate.Date.Month == (DateTime.Today.AddMonths(-3)).Month).ToList();
            var paymentMonth4 = payments.Where(x => x.PaymentDate.Year == DateTime.Today.AddMonths(-2).Year
                                                && x.PaymentDate.Date.Month == (DateTime.Today.AddMonths(-2)).Month).ToList();
            var paymentMonth5 = payments.Where(x => x.PaymentDate.Year == DateTime.Today.AddMonths(-1).Year
                                                && x.PaymentDate.Date.Month == (DateTime.Today.AddMonths(-1)).Month).ToList();
            var paymentMonth6 = payments.Where(x => x.PaymentDate.Year == DateTime.Today.Year
                                                && x.PaymentDate.Date.Month == DateTime.Today.Month).ToList();


            ViewBag.PaymentMonth1 = paymentMonth1;
            ViewBag.PaymentMonth2 = paymentMonth2;
            ViewBag.PaymentMonth3 = paymentMonth3;
            ViewBag.PaymentMonth4 = paymentMonth4;
            ViewBag.PaymentMonth5 = paymentMonth5;
            ViewBag.PaymentMonth6 = paymentMonth6;
            return View();
        }
    }
}
