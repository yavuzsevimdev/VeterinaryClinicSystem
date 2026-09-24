using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentQuickInfosComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _ManagerAppointmentQuickInfosComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto appointment)
        {
            ViewBag.Animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);
            return View(appointment);
        }
    }
}
