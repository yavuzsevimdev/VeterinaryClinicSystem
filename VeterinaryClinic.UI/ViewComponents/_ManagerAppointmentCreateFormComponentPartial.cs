using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentCreateFormComponentPartial :ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly IAnimalService _animalService;

        public _ManagerAppointmentCreateFormComponentPartial(IAppointmentService appointmentService, IUserService userService, IAnimalService animalService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var owners = await _userService.GetAllCustomersAsync();
            ViewBag.Owners = owners;

            var animals = await _animalService.GetAllAnimalsAsync();
            ViewBag.Animals = animals;

            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            ViewBag.AppointmentTypes = appointments.Select(x => x.AppointmentType).Distinct().ToList();
            return View();
        }
    }
}
