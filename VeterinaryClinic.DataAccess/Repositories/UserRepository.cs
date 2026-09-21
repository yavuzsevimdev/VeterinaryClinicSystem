using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DataAccess.Context;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VeterinaryClinicDbContext _context;

        public UserRepository(VeterinaryClinicDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

        }
    }
}
