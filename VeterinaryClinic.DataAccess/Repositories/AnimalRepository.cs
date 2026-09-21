using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DataAccess.Context;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(VeterinaryClinicDbContext context) : base(context)
        {
        }

        public async Task<List<Animal>> GetByOwnerIdAsync(string ownerId)
        {
            return await _context.Animals.Where(x => x.OwnerId == ownerId).ToListAsync();
        }
    }
}
