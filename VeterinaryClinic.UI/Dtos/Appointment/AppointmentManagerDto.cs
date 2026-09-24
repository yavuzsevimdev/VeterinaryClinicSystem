using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Dtos.User;

namespace VeterinaryClinic.UI.Dtos.Appointment
{
    public class AppointmentManagerDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string AppointmentType { get; set; }

        public UserDto Owner { get; set; }
        public AnimalDto Animal { get; set; }
    }
}
