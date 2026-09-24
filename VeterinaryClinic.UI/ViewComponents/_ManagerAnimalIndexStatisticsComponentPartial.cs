using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAnimalIndexStatisticsComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _ManagerAnimalIndexStatisticsComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetAllAnimalsAsync();

            ViewBag.TotalAnimalCount = animals.Count();
            ViewBag.TotalDogCount = animals.Count(a => a.Species == "Köpek");
            ViewBag.TotalCatCount = animals.Count(a => a.Species == "Kedi");
            ViewBag.TotalOtherCount = animals.Count(a => a.Species != "Köpek" && a.Species != "Kedi");
            return View();
        }
    }
}
