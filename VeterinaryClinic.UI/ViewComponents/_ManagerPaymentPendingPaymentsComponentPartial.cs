using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentPendingPaymentsComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _ManagerPaymentPendingPaymentsComponentPartial(IPaymentService paymentService, ITreatmentService treatmentService, IAppointmentService appointmentService, IAnimalService animalService, IUserService userService)
        {
            _paymentService = paymentService;
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var treatments = await _treatmentService.GetAllTreatmentsAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var animals = await _animalService.GetAllAnimalsAsync();
            var users = await _userService.GetAllCustomersAsync();

            var pendingPayments = new List<AppointmentDto>();
            var listOfPendingPayments = new List<(string AnimalName, string ImageUrl, string OwnerFullName, string AppointmentType, decimal TreatmentCost, decimal AmountPaid, decimal RemaningCost, int AppointmentId, int? PaymentId)>();
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

                if (!(appointmentTotalPaid >= appointmentTotalCost))
                {
                    pendingPayments.Add(appointment);
                }
            }

            foreach (var item in pendingPayments)
            {
                decimal remaningCost = 0;

                var animal = animals.FirstOrDefault(x => x.Id == item.AnimalId);
                var owner = users.FirstOrDefault(x => x.Id == animal.OwnerId);
                var treatmentCost = treatments.Where(x => x.AppointmentId == item.Id).Sum(x => x.Cost);
                var amountPaid = payments.Where(x => x.AppointmentId == item.Id).Sum(x => x.AmountPaid);
                var payment = payments.FirstOrDefault(x => x.AppointmentId == item.Id);

                if (payment == null)
                {
                    remaningCost = treatmentCost;
                    listOfPendingPayments.Add((animal.Name, animal.ImageUrl, owner.FullName, item.AppointmentType, treatmentCost, amountPaid, remaningCost, item.Id, null));
                }
                else
                {
                    remaningCost = treatmentCost - amountPaid;
                    listOfPendingPayments.Add((animal.Name, animal.ImageUrl, owner.FullName, item.AppointmentType, treatmentCost, amountPaid, remaningCost, item.Id, payment.Id));
                }
            }
            return View(listOfPendingPayments);
        }
    }
}
