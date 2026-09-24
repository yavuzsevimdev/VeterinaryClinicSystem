using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAnimalCreateFormComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _ManagerAnimalCreateFormComponentPartial(IAnimalService animalService, IUserService userService)
        {
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetAllAnimalsAsync();
            ViewBag.Species = animals
                            .Select(x => x.Species)
                            .Where(x => !string.IsNullOrWhiteSpace(x))
                            .Distinct()
                            .OrderBy(x => x)
                            .ToList();

            var users = await _userService.GetAllUsersAsync();
            ViewBag.Users = users;
            return View();
        }
    }
}
