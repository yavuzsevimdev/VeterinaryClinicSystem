namespace VeterinaryClinic.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string AppointmentType { get; set; }

        public Animal Animal { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
