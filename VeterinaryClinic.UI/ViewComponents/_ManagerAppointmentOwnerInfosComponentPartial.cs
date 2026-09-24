using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentOwnerInfosComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _ManagerAppointmentOwnerInfosComponentPartial(IAnimalService animalService, IUserService userService)
        {
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto appointment)
        {
            var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);
            var owner = (await _userService.GetAllUsersAsync()).FirstOrDefault(x => x.Id == animal.OwnerId);

            ViewBag.Owner = owner;
            return View();
        }
    }
}
