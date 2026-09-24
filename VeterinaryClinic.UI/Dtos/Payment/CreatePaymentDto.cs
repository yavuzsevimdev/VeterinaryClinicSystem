namespace VeterinaryClinic.UI.Dtos.Payment
{
    public class CreatePaymentDto
    {
        public int AppointmentId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
