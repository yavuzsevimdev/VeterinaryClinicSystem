using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentDetailOwnerInfosComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _AppointmentDetailOwnerInfosComponentPartial(IAppointmentService appointmentService, IAnimalService animalService, IUserService userService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);
            var user = await _userService.GetMyProfileAsync();

            return View(user);
        }
    }
}
