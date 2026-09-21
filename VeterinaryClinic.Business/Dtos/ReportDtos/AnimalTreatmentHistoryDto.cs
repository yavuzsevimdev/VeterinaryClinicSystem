namespace VeterinaryClinic.Business.Dtos.ReportDtos
{
    public class AnimalTreatmentHistoryDto
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string TreatmentType { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
    }
}
