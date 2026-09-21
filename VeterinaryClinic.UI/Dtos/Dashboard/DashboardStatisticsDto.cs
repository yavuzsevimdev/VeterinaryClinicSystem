namespace VeterinaryClinic.UI.Dtos.Dashboard
{
    public class DashboardStatisticsDto
    {
        public int AnimalsCount { get; set; }
        public int UpcomingAppointmentsCount { get; set; }
        public int TreatmentsCount { get; set; }
        public decimal OutstandingBalance { get; set; }
    }
}
