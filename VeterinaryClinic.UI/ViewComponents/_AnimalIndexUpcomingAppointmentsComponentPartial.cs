using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalIndexUpcomingAppointmentsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentsService;

        public _AnimalIndexUpcomingAppointmentsComponentPartial(IAppointmentService appointmentsService)
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
