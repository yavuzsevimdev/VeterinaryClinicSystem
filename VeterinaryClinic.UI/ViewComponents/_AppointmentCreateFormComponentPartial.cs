using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentCreateFormComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _AppointmentCreateFormComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetMyAnimalsAsync();
            ViewBag.Animals = animals;
            return View();
        }
    }
}
