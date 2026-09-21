namespace VeterinaryClinic.UI.Dtos.Dashboard
{
    public class ManagerDashboardStatisticsDto
    {
        public int TotalAnimals { get; set; }
        public int TodayAppointments { get; set; }
        public int CompletedTreatments { get; set; }
        public decimal OutstandingDebt { get; set; }
        public int ScheduledRemainingToday { get; set; }
    }
}
