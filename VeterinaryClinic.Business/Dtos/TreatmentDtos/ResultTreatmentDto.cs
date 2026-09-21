namespace VeterinaryClinic.Business.Dtos.TreatmentDtos
{
    public class ResultTreatmentDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string TreatmentType { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
    }
}
