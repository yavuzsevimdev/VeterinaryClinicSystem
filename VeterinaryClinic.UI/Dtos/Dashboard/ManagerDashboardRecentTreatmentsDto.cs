namespace VeterinaryClinic.UI.Dtos.Dashboard
{
    public class ManagerDashboardRecentTreatmentsDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string AnimalName { get; set; }
        public string TreatmentType { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
    }
}
