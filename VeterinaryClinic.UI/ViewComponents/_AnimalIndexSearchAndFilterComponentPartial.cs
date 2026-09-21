using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalIndexSearchAndFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
