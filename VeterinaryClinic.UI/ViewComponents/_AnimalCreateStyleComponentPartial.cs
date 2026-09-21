using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalCreateStyleComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
