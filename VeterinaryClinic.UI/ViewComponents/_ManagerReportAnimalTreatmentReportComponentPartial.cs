using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerReportAnimalTreatmentReportComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;
        private readonly ITreatmentService _treatmentService;

        public _ManagerReportAnimalTreatmentReportComponentPartial(IAnimalService animalService, ITreatmentService treatmentService)
        {
            _animalService = animalService;
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetAllAnimalsAsync();
            var treatments = await _treatmentService.GetAllTreatmentsAsync();
            ViewBag.TotalAnimals = animals.Count();
            ViewBag.TotalTreatments = treatments.Count();
            ViewBag.TotalCost = treatments.Sum(x => x.Cost);
            return View();
        }
    }
}
