using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalIndexAnimalListComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _AnimalIndexAnimalListComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetMyAnimalsAsync();
            return View(animals);
        }
    }
}
