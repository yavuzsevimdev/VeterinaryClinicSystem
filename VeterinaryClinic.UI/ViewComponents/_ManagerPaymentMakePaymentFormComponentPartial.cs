using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Payment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentMakePaymentFormComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int appointmentId)
        {
            var model = new CreatePaymentDto();
            ViewBag.AppointmentId = appointmentId;
            return View(model);
        }
    }
}
