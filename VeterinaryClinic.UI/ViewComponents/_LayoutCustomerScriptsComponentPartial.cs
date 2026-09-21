using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _LayoutCustomerScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
