using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.UI.Services.Appointment;
using VeterinaryClinic.UI.Services.Payment;

namespace VeterinaryClinic.UI.ViewComponents
{
    public class _ManagerPaymentRevenueComponentPartial : ViewComponent
    {
        private readonly IPaymentService _paymentService;
        private readonly IAppointmentService _appointmentService;

        public _ManagerPaymentRevenueComponentPartial(IPaymentService paymentService, IAppointmentService appointmentService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var appointments = await _appointmentService.GetAllAppointmentsAsync();

            var totalAmountPaid = payments.Sum(x => x.AmountPaid);

            decimal generalCheck = 0;
            decimal followUpExamination = 0;
            decimal vaccineAdministration = 0;
            decimal skinExamination = 0;
            decimal dentalExamination = 0;
            decimal other = 0;

            foreach (var item in payments)
            {
                var value = appointments.FirstOrDefault(x => x.Id == item.Id);
                if (value == null)
                    continue;
                if (value.AppointmentType == "Genel Kontrol")
                    generalCheck+=item.AmountPaid;
                else if (value.AppointmentType == "Kontrol Muayenesi")
                    followUpExamination += item.AmountPaid;
                else if(value.AppointmentType == "Aşı Uygulaması")
                    vaccineAdministration += item.AmountPaid;
                else if (value.AppointmentType == "Deri Muayenesi")
                    skinExamination += item.AmountPaid;
                else if(value.AppointmentType == "Diş Muayenesi")
                    dentalExamination += item.AmountPaid;
                else
                    other += item.AmountPaid;
            }


            var generalCheckRate = Math.Round((generalCheck / totalAmountPaid) * 100);
            var followUpExaminationRate = Math.Round((followUpExamination / totalAmountPaid) * 100);
            var vaccineAdministrationRate = Math.Round((vaccineAdministration / totalAmountPaid) * 100);
            var skinExaminationRate = Math.Round((skinExamination / totalAmountPaid) * 100);
            var dentalExaminationRate = Math.Round((dentalExamination / totalAmountPaid) * 100);
            var otherRate = Math.Round((other / totalAmountPaid) * 100);


            ViewBag.GeneralCheck = generalCheck;
            ViewBag.FollowUpExamination = followUpExamination;
            ViewBag.VaccineAdministration = vaccineAdministration;
            ViewBag.SkinExamination = skinExamination;
            ViewBag.DentalExamination = dentalExamination;
            ViewBag.Other = other;

            ViewBag.GeneralCheckRate = generalCheckRate;
            ViewBag.FollowUpExaminationRate = followUpExaminationRate;
            ViewBag.VaccineAdministrationRate = vaccineAdministrationRate;
            ViewBag.SkinExaminationRate = skinExaminationRate;
            ViewBag.DentalExaminationRate = dentalExaminationRate;
            ViewBag.OtherRate = otherRate;
            return View();
        }
    }
}
