using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DataAccess.Context;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(VeterinaryClinicDbContext context) : base(context)
        {
        }

        public async Task<List<Payment>> GetByOwnerIdAsync(string ownerId)
        {
            return await _context.Payments.Where(x => x.Appointment.Animal.OwnerId == ownerId).ToListAsync();
        }

        public async Task<decimal> GetTotalPaidAsync(int appointmentId)
        {
            return await _context.Payments.Where(x => x.AppointmentId == appointmentId).Select(x => x.AmountPaid).SumAsync();
        }
    }
}
