using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Dtos.Treatment;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AnimalDetailLatestTreatmentsComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IAppointmentService _appointmentService;

        public _AnimalDetailLatestTreatmentsComponentPartial(ITreatmentService treatmentService, IAppointmentService appointmentService)
        {
            _treatmentService = treatmentService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var treatments = await _treatmentService.GetMyTreatmentsAsync();
            var appointment = new AppointmentDto();
            var latestTreatments = new List<LatestTreatmentDto>();
            foreach (var item in treatments)
            {
                appointment = await _appointmentService.GetAppointmentByIdAsync(item.AppointmentId);
                if (appointment != null && appointment.AnimalId == id)
                {
                    latestTreatments.Add(new LatestTreatmentDto
                    {
                        Id = item.Id,
                        AnimalId = id,
                        AppointmentId = item.AppointmentId,
                        Notes = item.Notes,
                        Cost = item.Cost,
                        Date = appointment.Date,
                        Time = appointment.Time,
                        Status = appointment.Status,
                        TreatmentType = item.TreatmentType
                    });
                }
            }

            return View(latestTreatments.OrderByDescending(x => x.Date).Take(3).ToList());
        }
    }
}
