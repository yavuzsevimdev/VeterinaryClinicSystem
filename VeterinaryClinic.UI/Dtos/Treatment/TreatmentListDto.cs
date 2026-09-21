using VeterinaryClinic.UI.Dtos.Animal;
using VeterinaryClinic.UI.Dtos.Appointment;

namespace VeterinaryClinic.UI.Dtos.Treatment
{
    public class TreatmentListDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string TreatmentType { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
        public DateTime? Date { get; set; }

        public AnimalDto Animal { get; set; }
        public AppointmentDto Appointment { get; set; }
    }
}
