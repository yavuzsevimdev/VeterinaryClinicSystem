using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalIndexHeaderComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _AnimalIndexHeaderComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _animalService.GetMyAnimalsAsync();
            ViewBag.animalCount = values.Count;
            return View();
        }
    }
}
