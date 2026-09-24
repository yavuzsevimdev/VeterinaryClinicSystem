using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Dtos.User;

namespace VeterinaryClinic.UI.Dtos.Animal
{
    public class AnimalListAtManagerDto
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string MedicalHistory { get; set; }
        public string? City { get; set; }
        public string? ImageUrl { get; set; }
        public  UserDto Owner { get; set; }
        public  AppointmentDto? LastAppointment { get; set; }
    }
}
