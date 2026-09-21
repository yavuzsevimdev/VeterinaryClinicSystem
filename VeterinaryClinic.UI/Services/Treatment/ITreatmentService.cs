using VeterinaryClinic.UI.Dtos.Treatment;

namespace VeterinaryClinic.UI.Services.Treatment
{
    public interface ITreatmentService
    {
        Task<List<TreatmentDto>> GetMyTreatmentsAsync();
    }
}
