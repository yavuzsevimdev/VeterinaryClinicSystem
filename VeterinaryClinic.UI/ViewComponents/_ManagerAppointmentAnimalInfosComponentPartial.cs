using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentAnimalInfosComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _ManagerAppointmentAnimalInfosComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto appointment)
        {
            var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);
            ViewBag.Animal = animal;
            return View();
        }
    }
}
