using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerReportFinancialReportComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IPaymentService _paymentService;

        public _ManagerReportFinancialReportComponentPartial(ITreatmentService treatmentService, IPaymentService paymentService)
        {
            _treatmentService = treatmentService;
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var annualTreatments = (await _treatmentService.GetAllTreatmentsAsync()).Where(x => x.Date.Value.Year == DateTime.Today.Year).ToList();
            ViewBag.AnnualTreatmentsTotalCost = annualTreatments.Sum(x => x.Cost);

            var annualPayments = (await _paymentService.GetAllPaymentsAsync()).Where(x => x.PaymentDate.Year == DateTime.Today.Year).ToList();
            ViewBag.AnnualPaymentsAmountPaid = annualPayments.Sum(x => x.AmountPaid);

            ViewBag.RemaningAmount = annualTreatments.Sum(x => x.Cost) - annualPayments.Sum(x => x.AmountPaid);

            return View();
        }
    }
}
