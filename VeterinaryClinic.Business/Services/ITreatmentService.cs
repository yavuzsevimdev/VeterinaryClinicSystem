using VeterinaryClinic.Business.Dtos.TreatmentDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public interface ITreatmentService
    {
        Task<List<ResultTreatmentDto>> GetAllAsync();
        Task<GetTreatmentByIdDto> GetByIdAsync(int id);
        Task AddAsync(CreateTreatmentDto dto);
        Task UpdateAsync(UpdateTreatmentDto dto);
        Task DeleteAsync(int id);
        Task<List<ResultTreatmentDto>> GetByAnimalIdAsync(int animalId);
        Task<List<ResultTreatmentDto>> GetByOwnerIdAsync(string ownerId);
        Task<decimal> TotalCostAsync(int appointmentId);
    }
}
