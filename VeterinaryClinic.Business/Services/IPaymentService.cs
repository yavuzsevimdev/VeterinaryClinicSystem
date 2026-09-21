using VeterinaryClinic.Business.Dtos.PaymentDtos;

namespace VeterinaryClinic.Business.Services
{
    public interface IPaymentService
    {
        Task<List<ResultPaymentDto>> GetAllAsync();
        Task<GetPaymentByIdDto> GetByIdAsync(int id);
        Task AddAsync(CreatePaymentDto dto);
        Task UpdateAsync(UpdatePaymentDto dto);
        Task DeleteAsync(int id);
        Task<decimal> GetDebtAsync(int appointmentId);
        Task<decimal> GetTotalDebtByOwnerIdAsync(string ownerId);
        Task<List<ResultPaymentDto>> GetByOwnerIdAsync(string ownerId);
    }
}
