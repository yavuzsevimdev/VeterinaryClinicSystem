using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAnimalDetailOwnerInfosComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;

        public _ManagerAnimalDetailOwnerInfosComponentPartial(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AnimalDto animal)
        {
            var owner = (await _userService.GetAllCustomersAsync()).FirstOrDefault(x => x.Id == animal.OwnerId);
            ViewBag.Owner = owner;
            return View();
        }
    }
}
