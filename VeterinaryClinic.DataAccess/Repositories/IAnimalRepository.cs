using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        Task<List<Animal>> GetByOwnerIdAsync(string ownerId);
    }
}
