using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _CustomerDashboardFinancialSummaryComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IPaymentService _paymentService;

        public _CustomerDashboardFinancialSummaryComponentPartial(ITreatmentService treatmentService, IPaymentService paymentService)
        {
            _treatmentService = treatmentService;
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var treatments = await _treatmentService.GetMyTreatmentsAsync();
            decimal totalCost = treatments?.Sum(x => x.Cost) ?? 0;
            ViewBag.TotalCost = totalCost;

            var payments = await _paymentService.GetMyPaymentsAsync();
            decimal totalPaid = payments?.Sum(x => x.AmountPaid) ?? 0;
            ViewBag.TotalPaid = totalPaid;

            ViewBag.Outstanding = totalCost - totalPaid;
            return View();
        }
    }
}
