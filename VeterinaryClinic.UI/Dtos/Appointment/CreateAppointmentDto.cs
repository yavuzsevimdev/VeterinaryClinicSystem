namespace VeterinaryClinic.UI.Dtos.Appointment
{
    public class CreateAppointmentDto
    {
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; } = "Scheduled";
        public string Notes { get; set; }
        public string AppointmentType { get; set; }
    }
}
