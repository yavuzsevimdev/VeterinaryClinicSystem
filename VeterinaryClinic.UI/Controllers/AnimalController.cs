using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public AnimalController(IAnimalService animalService, IUserService userService)
        {
            _animalService = animalService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AnimalDto dto)
        {
            var result = await _animalService.CreateAsync(dto);
            if (result == null)
            {
                ModelState.AddModelError("", "Hayvan kaydı oluşturulurken bir hata oluştu.");
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            return View(animal);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            if (animal == null)
                return NotFound();

            ViewBag.OwnerFullName = (await _userService.GetAllUsersAsync()).Where(x => x.Id == animal.OwnerId).Select(x => x.FullName).FirstOrDefault();

            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AnimalDto dto)
        {
            var result = await _animalService.UpdateAsync(dto);
            if (result == null)
            {
                ModelState.AddModelError("", "Hayvan güncellenirken bir hata oluştu.");
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _animalService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
