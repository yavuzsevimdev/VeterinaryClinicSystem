using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Services.Animal;

namespace VeterinaryClinic.UI.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
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
