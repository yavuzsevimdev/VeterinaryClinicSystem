using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalDetailRecentAppointmentsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentsService;

        public _AnimalDetailRecentAppointmentsComponentPartial(IAppointmentService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int animalId)
        {
            var values = await _appointmentsService.GetAnimalAppointmentsAsync(animalId);
            return View(values.Take(3).ToList());
        }
    }
}
