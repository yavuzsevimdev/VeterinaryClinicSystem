using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<List<Payment>> GetByOwnerIdAsync(string ownerId);
        Task<decimal> GetTotalPaidAsync(int appointmentId);
    }
}
