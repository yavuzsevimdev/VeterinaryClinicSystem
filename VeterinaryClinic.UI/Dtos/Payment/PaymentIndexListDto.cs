using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Dtos.Appointment;

namespace VeterinaryClinic.UI.Dtos.Payment
{
    public class PaymentIndexListDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalDebt { get; set; }
        public AnimalDto Animal { get; set; }
        public AppointmentDto Appointment { get; set; }
    }
}
