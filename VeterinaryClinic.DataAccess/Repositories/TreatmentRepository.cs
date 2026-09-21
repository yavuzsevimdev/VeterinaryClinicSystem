using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DataAccess.Context;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public class TreatmentRepository : GenericRepository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(VeterinaryClinicDbContext context) : base(context)
        {
        }

        public async Task<List<Treatment>> GetByAnimalIdAsync(int animalId)
        {
            return await _context.Treatments.Include(x => x.Appointment).ThenInclude(x => x.Animal).Where(x => x.Appointment.AnimalId == animalId).ToListAsync();
        }

        public async Task<List<Treatment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Treatments.Include(x => x.Appointment).Where(x => x.Appointment.Date >= startDate.Date && x.Appointment.Date <= endDate.Date).ToListAsync();
        }

        public async Task<List<Treatment>> GetByOwnerIdAsync(string ownerId)
        {
            return await _context.Treatments.Where(x => x.Appointment.Animal.OwnerId == ownerId).ToListAsync();
        }

        public async Task<decimal> TotalCostAsync(int appointmentId)
        {
            return await _context.Treatments.Where(x => x.AppointmentId == appointmentId).Select(x => x.Cost).SumAsync();
        }
    }
}
