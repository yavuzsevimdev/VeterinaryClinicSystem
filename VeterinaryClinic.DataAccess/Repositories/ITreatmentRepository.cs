using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public interface ITreatmentRepository : IGenericRepository<Treatment>
    {
        Task<List<Treatment>> GetByAnimalIdAsync(int animalId);
        Task<List<Treatment>> GetByOwnerIdAsync(string ownerId);
        Task<decimal> TotalCostAsync(int appointmentId);
        Task<List<Treatment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
