using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentPaymentSummaryComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly ITreatmentService _treatmentService;

        public _ManagerAppointmentPaymentSummaryComponentPartial(IPaymentService paymentService, ITreatmentService treatmentService)
        {
            _paymentService = paymentService;
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto appointment)
        {
            var treatments = (await _treatmentService.GetAllTreatmentsAsync()).Where(x => x.AppointmentId == appointment.Id).ToList();
            var payments = (await _paymentService.GetAllPaymentsAsync()).Where(x => x.AppointmentId == appointment.Id).ToList();

            var totalCost = treatments.Sum(x => x.Cost);
            var amountPaid = payments.Sum(x => x.AmountPaid);
            var outstandingDebt = totalCost - amountPaid;

            ViewBag.AmountPaid = amountPaid;
            ViewBag.TotalCost = totalCost;
            ViewBag.OutstandingDebt = outstandingDebt;

            return View();
        }
    }
}
