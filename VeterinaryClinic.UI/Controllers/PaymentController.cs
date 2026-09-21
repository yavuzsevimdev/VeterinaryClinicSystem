using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
