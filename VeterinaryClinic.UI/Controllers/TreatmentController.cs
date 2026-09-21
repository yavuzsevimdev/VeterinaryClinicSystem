using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.Controllers
{
    public class TreatmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.TreatmentId = id;
            return View();
        }
    }
}
