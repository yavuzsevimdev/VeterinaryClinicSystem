namespace VeterinaryClinic.Business.Dtos.AppointmentDtos
{
    public class CompleteAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string TreatmentType { get; set; }
        public string TreatmentNotes { get; set; }
        public decimal TreatmentCost { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
