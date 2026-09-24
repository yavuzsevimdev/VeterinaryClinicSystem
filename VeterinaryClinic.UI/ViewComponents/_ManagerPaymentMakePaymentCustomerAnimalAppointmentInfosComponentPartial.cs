using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Entities;
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
    public class _ManagerPaymentMakePaymentCustomerAnimalAppointmentInfosComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _ManagerPaymentMakePaymentCustomerAnimalAppointmentInfosComponentPartial(IAppointmentService appointmentService, IAnimalService animalService, IUserService userService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto dto)
        {
            var animal = await _animalService.GetAnimalByIdAsync(dto.AnimalId);
            var owner = (await _userService.GetAllCustomersAsync()).FirstOrDefault(x => x.Id == animal.OwnerId);
            var appointment = dto;
            var values = (owner: owner, animal: animal, appointment: appointment);
            return View(values);
        }
    }
}
