using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Dtos.Dashboard;

namespace VeterinaryClinic.UI.Services.Appointment
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAllAppointmentsAsync();
        Task<List<AppointmentDto>> GetMyAppointmentsAsync();
        Task<AppointmentDto> GetAppointmentByIdAsync(int id);
        Task<List<UpcomingAppointmentDto>> GetUpcomingAppointment();
        Task<List<AppointmentDto>> GetAnimalAppointmentsAsync(int id);
        Task<byte[]> DownloadPdfAsync(int appointmentId);
        Task<bool> CancelAppointmentAsync(int appointmentId);
        Task<string> CreateAppointmentAsync(AppointmentDto dto);
        Task<bool> UpdateAppointmentAsync(AppointmentDto dto);
    }
}
