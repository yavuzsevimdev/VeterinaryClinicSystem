using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentUpdateFormComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly IAnimalService _animalService;

        public _ManagerAppointmentUpdateFormComponentPartial(IAppointmentService appointmentService, IUserService userService, IAnimalService animalService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var owners = await _userService.GetAllCustomersAsync();
            ViewBag.Owners = owners;

            var animals = await _animalService.GetAllAnimalsAsync();
            ViewBag.Animals = animals;

            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            ViewBag.AppointmentTypes = appointments.Select(x => x.AppointmentType).Distinct().ToList();

            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

            var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);

            var owner = (await _userService.GetAllUsersAsync()).FirstOrDefault(x => x.Id == animal.OwnerId);

            ViewBag.Owner = owner;
            ViewBag.Animal = animal;

            return View(appointment);
        }
    }
}
