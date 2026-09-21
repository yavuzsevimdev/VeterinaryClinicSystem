namespace VeterinaryClinic.UI.Dtos.Report
{
    public class FinancialReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal TotalTreatmentCost { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDebt { get; set; }
    }
}
