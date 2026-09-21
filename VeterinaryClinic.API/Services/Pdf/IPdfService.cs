namespace VeterinaryClinic.API.Services.Pdf
{
    public interface IPdfService
    {
        byte[] CreateAppointmentReport(
            int appointmentId,
            string animalName,
            DateTime appointmentDate,
            TimeSpan appointmentTime,
            string status,
            string notes,
            string treatmentType,
            string treatmentNotes,
            decimal treatmentCost,
            decimal paymentAmount,
            string paymentMethod);
    }
}
