using VeterinaryClinic.UI.Dtos.Treatment;

namespace VeterinaryClinic.UI.Services.Treatment
{
    public interface ITreatmentService
    {
        Task<List<TreatmentDto>> GetMyTreatmentsAsync();
        Task<List<TreatmentDto>> GetAllTreatmentsAsync();
        Task<string> CreateTreatmentAsync(CreateTreatmentDto dto);
        Task<bool> UpdateTreatmentAsync(TreatmentDto dto);
        Task<bool> DeleteTreatmentAsync(int id);

    }
}
