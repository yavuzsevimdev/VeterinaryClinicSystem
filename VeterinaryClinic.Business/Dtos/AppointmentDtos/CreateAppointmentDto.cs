using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Business.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        [Range(1, int.MaxValue)]
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        [Required]
        public string Status { get; set; }
        public string Notes { get; set; }
        public string AppointmentType { get; set; }

    }
}
