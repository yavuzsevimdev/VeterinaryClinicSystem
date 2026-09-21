using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentDetailInfosComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;

        public _AppointmentDetailInfosComponentPartial(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _appointmentService.GetAppointmentByIdAsync(id);
            return View(value);
        }
    }
}
