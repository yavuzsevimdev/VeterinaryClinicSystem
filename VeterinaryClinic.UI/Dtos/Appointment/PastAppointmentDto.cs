namespace VeterinaryClinic.UI.Dtos.Appointment
{
    public class PastAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string AnimalName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string? ImageUrl { get; set; }
        public string? Breed { get; set; }
        public string? Species { get; set; }
    }
}
