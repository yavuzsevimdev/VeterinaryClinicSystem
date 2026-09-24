using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Treatment;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _TreatmenDetailAppointmentInfoComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;

        public _TreatmenDetailAppointmentInfoComponentPartial(ITreatmentService treatmentService, IAppointmentService appointmentService)
        {
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var treatments = new List<TreatmentDto>();
            if (User.IsInRole("Manager"))
            {
                treatments = await _treatmentService.GetAllTreatmentsAsync();
            }
            if (User.IsInRole("Customer"))
            {
                treatments = await _treatmentService.GetMyTreatmentsAsync();
            }
            var treatment = treatments.FirstOrDefault(x => x.Id == id);
            var appointment = await _appointmentService.GetAppointmentByIdAsync(treatment.AppointmentId);

            return View(appointment);
        }
    }
}
