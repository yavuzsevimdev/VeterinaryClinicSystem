namespace VeterinaryClinic.Business.Dtos.ReportDtos
{
    public class DailyAppointmentReportDto
    {
        public DateTime Date { get; set; }

        public int TotalAppointments { get; set; }
        public int ScheduledAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
    }
}
