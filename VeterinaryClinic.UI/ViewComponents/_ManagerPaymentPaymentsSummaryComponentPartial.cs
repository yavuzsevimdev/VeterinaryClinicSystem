using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentPaymentsSummaryComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;

        public _ManagerPaymentPaymentsSummaryComponentPartial(IPaymentService paymentService, ITreatmentService treatmentService, IAppointmentService appointmentService)
        {
            _paymentService = paymentService;
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var treatments = await _treatmentService.GetAllTreatmentsAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();

            var totalAmountPaid = payments.Sum(x => x.AmountPaid);
            var totalCost = treatments.Sum(x => x.Cost);
            var remainingAmount = totalCost - totalAmountPaid;

            var completedPayments = 0;
            var pendingPayments = 0;

            foreach (var appointment in appointments)
            {
                var appointmentTreatments = treatments
                    .Where(x => x.AppointmentId == appointment.Id)
                    .ToList();

                var appointmentPayments = payments
                    .Where(x => x.AppointmentId == appointment.Id)
                    .ToList();

                var appointmentTotalCost = appointmentTreatments.Sum(x => x.Cost);
                var appointmentTotalPaid = appointmentPayments.Sum(x => x.AmountPaid);

                if (appointmentTotalCost <= 0)
                    continue;

                if (appointmentTotalPaid >= appointmentTotalCost)
                {
                    completedPayments++;
                }
                else
                {
                    pendingPayments++;
                }
            }

            ViewBag.TotalCost = totalCost;
            ViewBag.TotalAmountPaid = totalAmountPaid;
            ViewBag.RemainingAmount = remainingAmount;
            ViewBag.CompletedPayments = completedPayments;
            ViewBag.PendingPayments = pendingPayments;
            return View();
        }
    }
}
