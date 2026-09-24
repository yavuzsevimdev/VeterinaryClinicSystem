using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Dtos.Payment;
using VeterinaryClinic.UI.Dtos.User;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentRecentPaymentsComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _ManagerPaymentRecentPaymentsComponentPartial(IPaymentService paymentService, IAppointmentService appointmentService, IAnimalService animalService, IUserService userService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var recentPayments = payments.OrderByDescending(x => x.PaymentDate).Take(5).ToList();

            var recentPaymentsList = new List<(UserDto User, AppointmentDto Appointment, AnimalDto Animal, PaymentDto Payment)>();

            foreach (var item in recentPayments)
            {
                var appointment = (await _appointmentService.GetAllAppointmentsAsync()).FirstOrDefault(x => x.Id == item.AppointmentId); 
                if (appointment == null)
                    continue;
                var animal = (await _animalService.GetAllAnimalsAsync()).FirstOrDefault(x => x.Id == appointment.AnimalId);
                if (animal == null)
                    continue;
                var user = (await _userService.GetAllCustomersAsync()).FirstOrDefault(x => x.Id == animal.OwnerId);
                if (user == null)
                    continue;

                recentPaymentsList.Add((user, appointment, animal, item));
            }

            ViewBag.RecentPaymentsList = recentPaymentsList;
            return View(recentPaymentsList);
        }
    }
}
