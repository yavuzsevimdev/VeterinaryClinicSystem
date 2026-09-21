using VeterinaryClinic.DataAccess.Repositories;
using VeterinaryClinic.DataAccess.UnitOfWork;
using AutoMapper;
using VeterinaryClinic.Business.Dtos.AnimalDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnimalService(IAnimalRepository animalRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResultAnimalDto>> GetAllAsync()
        {
            var values = await _animalRepository.GetAllAsync();
            return _mapper.Map<List<ResultAnimalDto>>(values);
        }

        public async Task<GetAnimalByIdDto> GetByIdAsync(int id)
        {
            var value = await _animalRepository.GetByIdAsync(id);
            return _mapper.Map<GetAnimalByIdDto>(value);
        }

        public async Task AddAsync(CreateAnimalDto dto)
        {
            var value = _mapper.Map<Animal>(dto);
            await _animalRepository.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(UpdateAnimalDto dto)
        {
            var value = await _animalRepository.GetByIdAsync(dto.Id);

            value.OwnerId = dto.OwnerId;
            value.Name = dto.Name;
            value.Age = dto.Age;
            value.Weight = dto.Weight;
            value.Height = dto.Height;
            value.Species = dto.Species;
            value.Breed = dto.Breed;
            value.MedicalHistory = dto.MedicalHistory;
            value.City = dto.City;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _animalRepository.GetByIdAsync(id);
            _animalRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultAnimalDto>> GetByOwnerIdAsync(string ownerId)
        {
            var values = await _animalRepository.GetByOwnerIdAsync(ownerId);
            return _mapper.Map<List<ResultAnimalDto>>(values);
        }
    }
}
