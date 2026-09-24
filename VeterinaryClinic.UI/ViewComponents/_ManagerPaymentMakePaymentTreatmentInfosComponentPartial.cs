using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Dtos.Appointment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentMakePaymentTreatmentInfosComponentPartial : ViewComponent
    {
        private readonly ITreatmentService _treatmentService;

        public _ManagerPaymentMakePaymentTreatmentInfosComponentPartial(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(AppointmentDto dto)
        {
            var treatments = (await _treatmentService.GetAllTreatmentsAsync()).Where(x => x.AppointmentId == dto.Id).ToList();
            return View(treatments);
        }
    }
}
