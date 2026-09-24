using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalCreateFormComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Species = new List<string>
            {
                "Kedi",
                "Köpek",
                "Kuş",
                "Tavşan",
                "Hamster",
                "Balık"
            };
            return View();
        }
    }
}
