using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Payment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentMakePreviousPaymentsComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;

        public _ManagerPaymentMakePreviousPaymentsComponentPartial(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto dto)
        {
            var payments = (await _paymentService.GetAllPaymentsAsync()).Where(x => x.AppointmentId == dto.Id).ToList();
            if (payments == null)
                return View();
            return View(payments);
        }
    }
}
