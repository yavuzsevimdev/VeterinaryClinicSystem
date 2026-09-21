using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Payment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _PaymentIndexPaymentListComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly IAnimalService _animalService;
        private readonly IAppointmentService _appointmentService;
        private readonly ITreatmentService _treatmentService;

        public _PaymentIndexPaymentListComponentPartial(IPaymentService paymentService, IAnimalService animalService, IAppointmentService appointmentService, ITreatmentService treatmentService)
        {
            _paymentService = paymentService;
            _animalService = animalService;
            _appointmentService = appointmentService;
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetMyPaymentsAsync();
            var treatments = await _treatmentService.GetMyTreatmentsAsync();

            var paymentList = new List<PaymentIndexListDto>();

            foreach (var payment in payments) 
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(payment.AppointmentId);
                decimal totalDebt = 0;
                foreach (var treatment in treatments)
                {
                    if (treatment.AppointmentId == appointment.Id)
                    {
                        totalDebt += treatment.Cost;
                    }
                }
                paymentList.Add(new PaymentIndexListDto
                {
                    Id = payment.Id,
                    AppointmentId = payment.AppointmentId,
                    AmountPaid = payment.AmountPaid,
                    PaymentDate = payment.PaymentDate,
                    PaymentMethod = payment.PaymentMethod,
                    TotalDebt = totalDebt,
                    Animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId),
                    Appointment = appointment
                });

            }


            return View(paymentList);
        }
    }
}
