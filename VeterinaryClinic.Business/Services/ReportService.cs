using VeterinaryClinic.Business.Dtos.ReportDtos;
using VeterinaryClinic.DataAccess.Repositories;

namespace VeterinaryClinic.Business.Services
{
    public class ReportService : IReportService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAnimalRepository _animalRepository;

        public ReportService(IAppointmentRepository appointmentRepository, ITreatmentRepository treatmentRepository, IPaymentRepository paymentRepository, IAnimalRepository animalRepository)
        {
            _appointmentRepository = appointmentRepository;
            _treatmentRepository = treatmentRepository;
            _paymentRepository = paymentRepository;
            _animalRepository = animalRepository;
        }

        public async Task<DailyAppointmentReportDto> GetDailyAppointmentReportAsync(DateTime date)
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            var dailyAppointments = appointments.Where(x => x.Date.Date == date.Date).ToList();

            var totalAppointments = dailyAppointments.Count;
            var scheduledAppointments = dailyAppointments.Count(x => x.Status == "Scheduled");
            var completedAppointments = dailyAppointments.Count(x => x.Status == "Completed");
            var cancelledAppointments = dailyAppointments.Count(x => x.Status == "Cancelled");

            return new DailyAppointmentReportDto
            {
                Date = date.Date,
                TotalAppointments = totalAppointments,
                ScheduledAppointments = scheduledAppointments,
                CompletedAppointments = completedAppointments,
                CancelledAppointments = cancelledAppointments
            };
        }

        public async Task<MonthlyAppointmentReportDto> GetMonthlyAppointmentReportAsync(DateTime date)
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            var monthlyAppointments = appointments.Where(x => x.Date.Year == date.Year && x.Date.Month == date.Month).ToList();

            var totalAppointments = monthlyAppointments.Count;
            var scheduledAppointments = monthlyAppointments.Count(x => x.Status == "Scheduled");
            var completedAppointments = monthlyAppointments.Count(x => x.Status == "Completed");
            var cancelledAppointments = monthlyAppointments.Count(x => x.Status == "Cancelled");

            return new MonthlyAppointmentReportDto
            {
                Date = date.Date,
                TotalAppointments = totalAppointments,
                ScheduledAppointments = scheduledAppointments,
                CompletedAppointments = completedAppointments,
                CancelledAppointments = cancelledAppointments
            };
        }

        public async Task<FinancialReportDto> GetFinancialReportAsync(DateTime startDate, DateTime endDate)
        {
            var treatments = await _treatmentRepository.GetByDateRangeAsync(startDate, endDate);
            var totalTreatmentCost = treatments.Sum(x => x.Cost);

            var payments = await _paymentRepository.GetAllAsync();
            var filteredPayments = payments.Where(x => x.PaymentDate.Date >= startDate.Date && x.PaymentDate.Date <= endDate.Date).ToList();
            var totalPaid = filteredPayments.Sum(x => x.AmountPaid);

            var totalDebt = totalTreatmentCost - totalPaid;

            return new FinancialReportDto
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalTreatmentCost = totalTreatmentCost,
                TotalPaid = totalPaid,
                TotalDebt = totalDebt
            };
        }

        public async Task<List<AnimalTreatmentHistoryDto>> GetAnimalTreatmentHistoryAsync(int animalId)
        {
            var treatments = await _treatmentRepository.GetByAnimalIdAsync(animalId);

            return treatments.Select(x => new AnimalTreatmentHistoryDto
            {
                AnimalId = x.Appointment.AnimalId,
                AnimalName = x.Appointment.Animal.Name,
                AppointmentDate = x.Appointment.Date,
                AppointmentTime = x.Appointment.Time,
                TreatmentType = x.TreatmentType,
                Notes = x.Notes,
                Cost = x.Cost
            }).ToList();
        }

        public async Task<List<AnimalTreatmentHistoryDto>> GetAllAnimalTreatmentHistoryAsync()
        {
            var animals = await _animalRepository.GetAllAsync();
            var result = new List<AnimalTreatmentHistoryDto>();
            foreach (var animal in animals)
            {
                var treatments = await GetAnimalTreatmentHistoryAsync(animal.Id);

                result.AddRange(treatments);
            }
            return result;
        }
    }
}
