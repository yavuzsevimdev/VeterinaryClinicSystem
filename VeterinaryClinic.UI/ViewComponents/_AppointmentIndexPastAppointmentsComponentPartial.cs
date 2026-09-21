using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Dtos.Dashboard;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _AppointmentIndexPastAppointmentsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;

        public _AppointmentIndexPastAppointmentsComponentPartial(IAppointmentService appointmentService, IAnimalService animalService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _appointmentService.GetMyAppointmentsAsync();
            var appointments = values.Where(x => x.Date < DateTime.Today || x.Status == "Cancelled")
                                     .OrderBy(x => x.Date)
                                     .ToList();
            if (appointments == null)
                return null;

            var pastAppointments = new List<PastAppointmentDto>();
            foreach (var item in appointments)
            {
                var animal = await _animalService.GetAnimalByIdAsync(item.AnimalId);
                pastAppointments.Add(new PastAppointmentDto
                {
                    AppointmentId = item.Id,
                    AnimalName = animal.Name,
                    Date = item.Date,
                    Time = item.Time,
                    Status = item.Status,
                    Notes = item.Notes,
                    ImageUrl = animal.ImageUrl,
                    Breed = animal.Breed,
                    Species = animal.Species
                });
            }
            return View(pastAppointments);
        }
    }
}
