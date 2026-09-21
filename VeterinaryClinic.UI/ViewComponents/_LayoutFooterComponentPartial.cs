using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
