using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAppointmentTodayAppointmentsComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;

        public _ManagerAppointmentTodayAppointmentsComponentPartial(IAppointmentService appointmentService, IAnimalService animalService, IUserService userService)
        {
            _appointmentService = appointmentService;
            _animalService = animalService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var todayAppointments = appointments.Where(x => x.Date.Date == DateTime.Today)
                                                  .OrderBy(x => x.Date)
                                                  .ThenBy(x => x.Time)
                                                  .ToList();

            var values = new List<AppointmentManagerDto>();

            foreach (var item in todayAppointments)
            {
                var animal = await _animalService.GetAnimalByIdAsync(item.AnimalId);
                var owner = (await _userService.GetAllUsersAsync()).FirstOrDefault(x => x.Id == animal.OwnerId);
                values.Add(new AppointmentManagerDto
                {
                    Animal = animal,
                    AnimalId = item.AnimalId,
                    AppointmentType = item.AppointmentType,
                    Date = item.Date,
                    Id = item.Id,
                    Notes = item.Notes,
                    Owner = owner,
                    Status = item.Status,
                    Time = item.Time
                });
            }
            return View(values);
        }
    }
}
