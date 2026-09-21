using VeterinaryClinic.Business.Dtos.AppointmentDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public interface IAppointmentService
    {
        Task<List<ResultAppointmentDto>> GetAllAsync();
        Task<GetAppointmentByIdDto> GetByIdAsync(int id);
        Task AddAsync(CreateAppointmentDto dto);
        Task UpdateAsync(UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
        Task<List<ResultAppointmentDto>> GetByAnimalIdAsync(int animalId);
        Task<List<ResultAppointmentDto>> GetByOwnerIdAsync(string ownerId);
        Task CompleteAppointmentAsync(CompleteAppointmentDto dto);
        Task<string?> GetOwnerIdByAppointmentIdAsync(int appointmentId);
        Task<Appointment?> GetAppointmentWithDetailsAsync(int id);
        Task CancelAsync(int id);
    }
}
