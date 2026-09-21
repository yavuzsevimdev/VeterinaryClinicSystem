using AutoMapper;
using VeterinaryClinic.Business.Dtos.PaymentDtos;
using VeterinaryClinic.DataAccess.Repositories;
using VeterinaryClinic.DataAccess.UnitOfWork;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IMapper mapper, ITreatmentRepository treatmentRepository, IAppointmentRepository appointmentRepository)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _treatmentRepository = treatmentRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<ResultPaymentDto>> GetAllAsync()
        {
            var values = await _paymentRepository.GetAllAsync();
            return _mapper.Map<List<ResultPaymentDto>>(values);
        }

        public async Task<GetPaymentByIdDto> GetByIdAsync(int id)
        {
            var value = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<GetPaymentByIdDto>(value);
        }

        public async Task AddAsync(CreatePaymentDto dto)
        {
            var value = _mapper.Map<Payment>(dto);
            await _paymentRepository.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdatePaymentDto dto)
        {
            var payment = await _paymentRepository.GetByIdAsync(dto.Id);
            payment.AppointmentId = dto.AppointmentId;
            payment.AmountPaid = dto.AmountPaid;
            payment.PaymentDate = dto.PaymentDate;
            payment.PaymentMethod = dto.PaymentMethod;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _paymentRepository.GetByIdAsync(id);
            _paymentRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<decimal> GetDebtAsync(int appointmentId)
        {
            var treatmentCost = await _treatmentRepository.TotalCostAsync(appointmentId);
            var totalPaid = await _paymentRepository.GetTotalPaidAsync(appointmentId);
            var debt = treatmentCost - totalPaid;
            return debt;
        }

        public async Task<List<ResultPaymentDto>> GetByOwnerIdAsync(string ownerId)
        {
            var values = await _paymentRepository.GetByOwnerIdAsync(ownerId);
            return _mapper.Map<List<ResultPaymentDto>>(values);
        }

        public async Task<decimal> GetTotalDebtByOwnerIdAsync(string ownerId)
        {
            var appointments = await _appointmentRepository.GetByOwnerIdAsync(ownerId);
            decimal totalTreatmentsCost = 0;
            decimal totalPaid = 0;
            foreach (var item in appointments)
            {
                totalTreatmentsCost += await _treatmentRepository.TotalCostAsync(item.Id);
                totalPaid += await _paymentRepository.GetTotalPaidAsync(item.Id);
            }
            var totalDebt = totalTreatmentsCost - totalPaid;
            return totalDebt;
        }
    }
}
