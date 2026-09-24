namespace VeterinaryClinic.UI.Dtos.Treatment
{
    public class CreateTreatmentDto
    {
        public int AppointmentId { get; set; }
        public string TreatmentType { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
        public DateTime? Date { get; set; }
    }
}
