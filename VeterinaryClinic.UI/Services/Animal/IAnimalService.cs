using VeterinaryClinic.UI.Dtos.Animal;

namespace VeterinaryClinic.UI.Services.Animal
{
    public interface IAnimalService
    {
        Task<List<AnimalDto>> GetMyAnimalsAsync();
        Task<AnimalDto> GetAnimalByIdAsync(int id);
        Task<List<AnimalDto>> GetAllAnimalsAsync();
        Task<string> CreateAsync(AnimalDto dto);
        Task<string> UpdateAsync(AnimalDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
