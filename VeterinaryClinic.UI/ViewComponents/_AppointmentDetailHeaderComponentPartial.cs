using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentDetailHeaderComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public _AppointmentDetailHeaderComponentPartial(IAppointmentService appointmentService, IAnimalService animalService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return Content("Randevu bulunamadı.");
            }

            var animal = await _animalService.GetAnimalByIdAsync(appointment.AnimalId);

            var appointmentDetail = new AppointmentDetailDto()
            {
                Id = appointment.Id,
                AnimalId = appointment.AnimalId,
                Date = appointment.Date,
                Time = appointment.Time,
                Status = appointment.Status,
                Notes = appointment.Notes,
                Animal = animal
            };
            return View(appointmentDetail);
        }
    }
}
