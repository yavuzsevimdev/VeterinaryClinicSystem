using VeterinaryClinic.UI.Dtos.Payment;

namespace VeterinaryClinic.UI.Services.Payment
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetMyPaymentsAsync();
        Task<decimal> GetTotalDebtAsync();
    }
}
