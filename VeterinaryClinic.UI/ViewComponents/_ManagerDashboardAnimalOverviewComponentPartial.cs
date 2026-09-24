using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerDashboardAnimalOverviewComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public _ManagerDashboardAnimalOverviewComponentPartial(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _animalService.GetAllAnimalsAsync();
            return View(values.Take(8).ToList());
        }
    }
}
