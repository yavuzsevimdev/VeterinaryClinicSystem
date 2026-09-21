using AutoMapper;
using VeterinaryClinic.Business.Dtos.AppointmentDtos;
using VeterinaryClinic.DataAccess.Repositories;
using VeterinaryClinic.DataAccess.UnitOfWork;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, IMapper mapper, ITreatmentRepository treatmentRepository, IPaymentRepository paymentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _treatmentRepository = treatmentRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<List<ResultAppointmentDto>> GetAllAsync()
        {
            var values = await _appointmentRepository.GetAllAsync();
            return _mapper.Map<List<ResultAppointmentDto>>(values);
        }

        public async Task<GetAppointmentByIdDto> GetByIdAsync(int id)
        {
            var value = await _appointmentRepository.GetByIdAsync(id);
            return _mapper.Map<GetAppointmentByIdDto>(value);
        }

        public async Task AddAsync(CreateAppointmentDto dto)
        {
            var value = _mapper.Map<Appointment>(dto);
            await _appointmentRepository.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateAppointmentDto dto)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(dto.Id);
            appointment.AnimalId = dto.AnimalId;
            appointment.Date = dto.Date;
            appointment.Time = dto.Time;
            appointment.Status = dto.Status;
            appointment.Notes = dto.Notes;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _appointmentRepository.GetByIdAsync(id);
            _appointmentRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultAppointmentDto>> GetByAnimalIdAsync(int animalId)
        {
            var values = await _appointmentRepository.GetByAnimalIdAsync(animalId);
            return _mapper.Map<List<ResultAppointmentDto>>(values);
        }

        public async Task<List<ResultAppointmentDto>> GetByOwnerIdAsync(string ownerId)
        {
            var values = await _appointmentRepository.GetByOwnerIdAsync(ownerId);
            return _mapper.Map<List<ResultAppointmentDto>>(values);
        }

        public async Task CompleteAppointmentAsync(CompleteAppointmentDto dto)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(dto.AppointmentId);

            if(appointment == null)
                throw new Exception("Randevu bulunamadı.");

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                appointment.Status = "Completed";

                var treatment = new Treatment
                {
                    AppointmentId = appointment.Id,
                    TreatmentType = dto.TreatmentType,
                    Notes = dto.TreatmentNotes,
                    Cost = dto.TreatmentCost
                };
                await _treatmentRepository.AddAsync(treatment);

                var payment = new Payment
                {
                    AppointmentId = appointment.Id,
                    AmountPaid = dto.PaymentAmount,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = dto.PaymentMethod
                };
                await _paymentRepository.AddAsync(payment);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<string?> GetOwnerIdByAppointmentIdAsync(int appointmentId)
        {
            return await _appointmentRepository.GetOwnerIdByAppointmentIdAsync(appointmentId);
        }

        public async Task<Appointment?> GetAppointmentWithDetailsAsync(int id)
        {
            var value = await _appointmentRepository.GetAppointmentWithDetailsAsync(id);
            return value;
        }

        public async Task CancelAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new Exception("Randevu bulunamadı.");

            appointment.Status = "Cancelled";

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
