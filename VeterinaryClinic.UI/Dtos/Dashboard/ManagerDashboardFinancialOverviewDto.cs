namespace VeterinaryClinic.UI.Dtos.Dashboard
{
    public class ManagerDashboardFinancialOverviewDto
    {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal TotalTreatmentCost { get; set; }
            public decimal TotalPaid { get; set; }
            public decimal TotalDebt { get; set; }
            public double PaidPercentage { get; set; }
            public double DebtPercentage { get; set; }
    }
}
