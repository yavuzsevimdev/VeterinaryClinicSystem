using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Animal;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;
using VeterinaryClinic.UI.Services.Treatment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerReportMonthlyReportComponentPartial : ViewComponent
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPaymentService _paymentService;
        private readonly ITreatmentService _treatmentService;
        private readonly IAnimalService _animalService;

        public _ManagerReportMonthlyReportComponentPartial(IAppointmentService appointmentService, IPaymentService paymentService, ITreatmentService treatmentService, IAnimalService animalService)
        {
            _appointmentService = appointmentService;
            _paymentService = paymentService;
            _treatmentService = treatmentService;
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var monthlyAppointment = (await _appointmentService.GetAllAppointmentsAsync()).Where(x => x.Date.Month == DateTime.Today.Month).ToList();
            ViewBag.MontlyhApppointmentCount = monthlyAppointment.Count();

            var monthlyTreatments = (await _treatmentService.GetAllTreatmentsAsync()).Where(x => x.Date.Value.Month == DateTime.Today.Month).ToList();
            ViewBag.MonthlyTreatmentCount = monthlyTreatments.Count();

            var montlyPayments = (await _paymentService.GetAllPaymentsAsync()).Where(x => x.PaymentDate.Month == DateTime.Today.Month).ToList();
            ViewBag.TotalAmountPaid = montlyPayments.Sum(x => x.AmountPaid);

            var animals = await _animalService.GetAllAnimalsAsync();
            ViewBag.TotalAnimals = animals.Count();

            return View();
        }
    }
}
