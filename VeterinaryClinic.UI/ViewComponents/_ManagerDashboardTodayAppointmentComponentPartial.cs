using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerDashboardTodayAppointmentComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public _ManagerDashboardTodayAppointmentComponentPartial(IAppointmentService appointmentService, IAnimalService animalService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var todayAppointments = appointments.Where(a => a.Date.Date == DateTime.Today).ToList();
            var values = new List<AppointmentDetailDto>();
            foreach (var appointment in todayAppointments)
            {
                values.Add(new AppointmentDetailDto
                {
                    Animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId),
                    Date = appointment.Date,
                    AnimalId = appointment.AnimalId,
                    Id = appointment.Id,
                    Notes = appointment.Notes,
                    Status = appointment.Status,
                    Time = appointment.Time
                });
            }
            return View(values);
        }
    }
}
