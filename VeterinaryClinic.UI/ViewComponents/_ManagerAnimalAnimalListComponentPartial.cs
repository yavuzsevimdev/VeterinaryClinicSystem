using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.User;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerAnimalAnimalListComponentPartial : ViewComponent
    {
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;

        public _ManagerAnimalAnimalListComponentPartial(IAnimalService animalService, IUserService userService, IAppointmentService appointmentService)
        {
            _animalService = animalService;
            _userService = userService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var animals = await _animalService.GetAllAnimalsAsync();
            var animalList = new List<AnimalListAtManagerDto>();
            var owners = await _userService.GetAllUsersAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            foreach (var item in animals)
            {
                animalList.Add(new AnimalListAtManagerDto
                {
                    Age = item.Age,
                    Breed = item.Breed,
                    City = item.City,
                    Height = item.Height,
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    MedicalHistory = item.MedicalHistory,
                    Name = item.Name,
                    Owner = owners.FirstOrDefault(x => x.Id == item.OwnerId),
                    LastAppointment = appointments.Where(x => x.AnimalId == item.Id).OrderByDescending(x => x.Date).FirstOrDefault(),
                    OwnerId = item.OwnerId,
                    Species = item.Species,
                    Weight = item.Weight
                });
            }
            return View(animalList);
        }
    }
}
