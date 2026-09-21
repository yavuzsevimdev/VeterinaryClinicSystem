using VeterinaryClinic.Business.Dtos.AnimalDtos;

namespace VeterinaryClinic.Business.Services
{
    public interface IAnimalService
    {
        Task<List<ResultAnimalDto>> GetAllAsync();
        Task<GetAnimalByIdDto> GetByIdAsync(int id);
        Task AddAsync(CreateAnimalDto dto);
        Task UpdateAsync(UpdateAnimalDto dto);
        Task DeleteAsync(int id);
        Task<List<ResultAnimalDto>> GetByOwnerIdAsync(string ownerId);
    }
}
