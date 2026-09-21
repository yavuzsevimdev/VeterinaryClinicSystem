namespace VeterinaryClinic.UI.Dtos.Appointment
{
    public class    AppointmentDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string AppointmentType { get; set; }
    }
}
