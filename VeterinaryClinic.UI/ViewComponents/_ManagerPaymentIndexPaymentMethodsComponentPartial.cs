using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Payment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentIndexPaymentMethodsComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;

        public _ManagerPaymentIndexPaymentMethodsComponentPartial(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var paymentMethods = payments.Select(x => x.PaymentMethod);


            var totalPayment = payments.Sum(x => x.AmountPaid);
            ViewBag.TotalPayment = totalPayment;


            var totalPaymentWithCreditCard = payments.Where(x => x.PaymentMethod == "Kredi Kartı").Sum(x => x.AmountPaid);
            var totalPaymentWithCash = payments.Where(x => x.PaymentMethod == "Nakit").Sum(x => x.AmountPaid);
            var totalPaymentWithEFTTransfer = payments.Where(x => x.PaymentMethod == "Havale/EFT").Sum(x => x.AmountPaid);
            var totalPaymentWithOther = totalPayment - totalPaymentWithCreditCard - totalPaymentWithCash - totalPaymentWithEFTTransfer;
            ViewBag.CreditCardPayments = totalPaymentWithCreditCard;
            ViewBag.CashPayments = totalPaymentWithCash;
            ViewBag.EFTTransferPayments = totalPaymentWithEFTTransfer;
            ViewBag.OtherPayments = totalPaymentWithOther;


            var creditCardPercentage = totalPayment == 0 ? 0 : (totalPaymentWithCreditCard / totalPayment) * 100;
            var cashPercentage = totalPayment == 0 ? 0 : (totalPaymentWithCash / totalPayment) * 100;
            var eftPercentage = totalPayment == 0 ? 0 : (totalPaymentWithEFTTransfer / totalPayment) * 100;
            var otherPercentage = totalPayment == 0 ? 0 : (totalPaymentWithOther / totalPayment) * 100;
            ViewBag.CreditCardPercentage = creditCardPercentage;
            ViewBag.CashPercentage = cashPercentage;
            ViewBag.EFTTransferPercentage = eftPercentage;
            ViewBag.OtherPercentage = otherPercentage;

            return View();
        }
    }
}
