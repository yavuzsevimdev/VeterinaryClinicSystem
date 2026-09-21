using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DataAccess.Context;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(VeterinaryClinicDbContext context) : base(context)
        {
        }

        public async Task<List<Appointment>> GetByAnimalIdAsync(int animalId)
        {
            return await _context.Appointments.Where(x => x.AnimalId == animalId).ToListAsync();
        }

        public async Task<List<Appointment>> GetByOwnerIdAsync(string ownerId)
        {
            return await _context.Appointments.Where(x => x.Animal.OwnerId == ownerId).ToListAsync();
        }

        public async Task<string?> GetOwnerIdByAppointmentIdAsync(int appointmentId)
        {
            return await _context.Appointments.Where(x => x.Id == appointmentId).Select(x => x.Animal.OwnerId).FirstOrDefaultAsync();
        }

        public async Task<Appointment?> GetAppointmentWithDetailsAsync(int id)
        {
            return await _context.Appointments
                .Include(x => x.Animal)
                .Include(x => x.Treatments)
                .Include(x => x.Payments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
