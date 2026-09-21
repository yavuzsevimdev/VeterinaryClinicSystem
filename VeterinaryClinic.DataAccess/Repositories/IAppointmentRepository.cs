using VeterinaryClinic.Entities;

namespace VeterinaryClinic.DataAccess.Repositories
{
    public interface IAppointmentRepository: IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetByAnimalIdAsync(int animalId);
        Task<List<Appointment>> GetByOwnerIdAsync(string ownerId);
        Task<string?> GetOwnerIdByAppointmentIdAsync(int appointmentId);
        Task<Appointment?> GetAppointmentWithDetailsAsync(int id);
    }
}
