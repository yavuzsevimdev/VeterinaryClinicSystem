using AutoMapper;
using VeterinaryClinic.Business.Dtos.TreatmentDtos;
using VeterinaryClinic.DataAccess.Repositories;
using VeterinaryClinic.DataAccess.UnitOfWork;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TreatmentService(ITreatmentRepository treatmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _treatmentRepository = treatmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResultTreatmentDto>> GetAllAsync()
        {
            var values = await _treatmentRepository.GetAllAsync();
            return _mapper.Map<List<ResultTreatmentDto>>(values);
        }

        public async Task<GetTreatmentByIdDto> GetByIdAsync(int id)
        {
            var value = await _treatmentRepository.GetByIdAsync(id);
            return _mapper.Map<GetTreatmentByIdDto>(value);
        }

        public async Task AddAsync(CreateTreatmentDto dto)
        {
            var value = _mapper.Map<Treatment>(dto);
            await _treatmentRepository.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateTreatmentDto dto)
        {
            var treatment = await _treatmentRepository.GetByIdAsync(dto.Id);
            treatment.AppointmentId = dto.AppointmentId;
            treatment.TreatmentType = dto.TreatmentType;
            treatment.Notes = dto.Notes;
            treatment.Cost = dto.Cost;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _treatmentRepository.GetByIdAsync(id);
            _treatmentRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultTreatmentDto>> GetByAnimalIdAsync(int animalId)
        {
            var values = await _treatmentRepository.GetByAnimalIdAsync(animalId);
            return _mapper.Map<List<ResultTreatmentDto>>(values);
        }

        public async Task<List<ResultTreatmentDto>> GetByOwnerIdAsync(string ownerId)
        {
            var values = await _treatmentRepository.GetByOwnerIdAsync(ownerId);
            return _mapper.Map<List<ResultTreatmentDto>>(values);
        }

        public async Task<decimal> TotalCostAsync(int appointmentId)
        {
            var totalCost = await _treatmentRepository.TotalCostAsync(appointmentId);
            return totalCost;
        }
    }
}
