using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Business.Dtos.PaymentDtos
{
    public class UpdatePaymentDto
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public int AppointmentId { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }
}
