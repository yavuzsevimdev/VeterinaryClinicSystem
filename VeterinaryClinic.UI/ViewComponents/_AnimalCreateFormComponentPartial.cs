using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Entities;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalCreateFormComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _AnimalCreateFormComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetMyAnimalsAsync();
            ViewBag.Species = animals
                            .Select(x => x.Species)
                            .Where(x => !string.IsNullOrWhiteSpace(x))
                            .Distinct()
                            .OrderBy(x => x)
                            .ToList();
            return View();
        }
    }
}
