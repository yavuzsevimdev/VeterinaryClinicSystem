using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Treatment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerTreatmentIndexRecentTreatmentsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
