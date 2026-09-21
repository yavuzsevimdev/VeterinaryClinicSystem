namespace VeterinaryClinic.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string TreatmentType { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public Appointment Appointment { get; set; }

    }
}
