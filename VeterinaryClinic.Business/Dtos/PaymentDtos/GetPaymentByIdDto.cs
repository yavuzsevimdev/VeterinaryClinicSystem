namespace VeterinaryClinic.Business.Dtos.PaymentDtos
{
    public class GetPaymentByIdDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
