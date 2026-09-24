using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentTopCustomersComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _ManagerPaymentTopCustomersComponentPartial(
            IPaymentService paymentService,
            IAppointmentService appointmentService,
            IAnimalService animalService,
            IUserService userService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var animals = await _animalService.GetAllAnimalsAsync();
            var users = await _userService.GetAllUsersAsync();

            var customerPayments = new List<(string UserId, decimal Amount)>();

            foreach (var payment in payments)
            {
                var appointment = appointments.FirstOrDefault(x => x.Id == payment.AppointmentId);
                if (appointment == null)
                    continue;

                var animal = animals.FirstOrDefault(x => x.Id == appointment.AnimalId);
                if (animal == null)
                    continue;

                customerPayments.Add((animal.OwnerId, payment.AmountPaid));
            }

            var topCustomers = customerPayments
                .GroupBy(x => x.UserId)
                .Select(x => new
                {
                    UserId = x.Key,
                    TotalPayment = x.Sum(y => y.Amount),
                    PaymentCount = x.Count()
                })
                .OrderByDescending(x => x.TotalPayment)
                .Take(5)
                .ToList();

            var result = topCustomers
                .Select(x => new
                {
                    User = users.FirstOrDefault(u => u.Id == x.UserId),
                    TotalPayment = x.TotalPayment,
                    PaymentCount = x.PaymentCount
                })
                .Where(x => x.User != null)
                .ToList();

            ViewBag.TopCustomers = result;

            return View();
        }
    }
}