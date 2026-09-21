using VeterinaryClinic.UI.Dtos.Treatment;

namespace VeterinaryClinic.UI.Dtos.Appointment
{
    public class AppointmentDetailTimelineDto
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public List<TreatmentDto> Treatments { get; set; }
    }
}
