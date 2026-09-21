using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DataAccess.Context;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VeterinaryClinicDbContext _context;

        public GenericRepository(VeterinaryClinicDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            var values = await _context.Set<T>().ToListAsync();
            return values;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            return value;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
