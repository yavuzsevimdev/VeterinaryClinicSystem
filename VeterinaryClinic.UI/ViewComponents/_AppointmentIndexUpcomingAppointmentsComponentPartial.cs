using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentIndexUpcomingAppointmentsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentsService;

        public _AppointmentIndexUpcomingAppointmentsComponentPartial(IAppointmentService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var appointments = await _appointmentsService.GetUpcomingAppointment();
            return View(appointments);
        }
    }
}
