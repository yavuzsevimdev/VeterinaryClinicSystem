using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Dashboard()
        {
            if (User.IsInRole("Manager"))
                return View("ManagerDashboard");

            return View("CustomerDashboard");
        }
    }
}
