using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Business.Dtos.TreatmentDtos
{
    public class CreateTreatmentDto
    {
        [Range(1, int.MaxValue)]
        public int AppointmentId { get; set; }

        [Required]
        public string TreatmentType { get; set; }
        public string Notes { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }

    }
}
