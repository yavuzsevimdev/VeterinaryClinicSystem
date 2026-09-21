using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinic.UI.ViewComponents
{

    public class _LayoutManagerHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
