using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentMakeSummaryComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IPaymentService _paymentService;

        public _ManagerPaymentMakeSummaryComponentPartial(ITreatmentService treatmentService, IPaymentService paymentService)
        {
            _treatmentService = treatmentService;
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto dto)
        {
            var totalCost = (await _treatmentService.GetAllTreatmentsAsync()).Where(x => x.AppointmentId == dto.Id).Sum(x => x.Cost);
            var payments = (await _paymentService.GetAllPaymentsAsync()).Where(x => x.AppointmentId == dto.Id).ToList();
            decimal amountPaid = 0;
            if (payments != null)
                amountPaid = payments.Sum(x => x.AmountPaid);

            ViewBag.AmountPaid = amountPaid;
            ViewBag.TotalCost = totalCost;
            ViewBag.RemaningAmount = totalCost - amountPaid;
            return View();
        }
    }
}
