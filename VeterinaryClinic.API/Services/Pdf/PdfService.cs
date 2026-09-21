using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace VeterinaryClinic.API.Services.Pdf
{
    public class PdfService : IPdfService
    {
        public byte[] CreateAppointmentReport(
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
            string paymentMethod)
        {
            var debt = treatmentCost - paymentAmount;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.Header()
                        .Text("Veterinary Clinic")
                        .FontSize(24)
                        .Bold();

                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            column.Spacing(10);

                            column.Item()
                                .Text("Appointment Report")
                                .FontSize(18)
                                .Bold();

                            column.Item()
                                .Text($"Appointment ID: {appointmentId}");

                            column.Item()
                                .Text($"Animal: {animalName}");

                            column.Item()
                                .Text($"Date: {appointmentDate:dd.MM.yyyy}");

                            column.Item()
                                .Text($"Time: {appointmentTime}");

                            column.Item()
                                .Text($"Status: {status}");

                            column.Item()
                                .PaddingTop(10)
                                .Text("Appointment Notes")
                                .Bold();

                            column.Item()
                                .Text(string.IsNullOrEmpty(notes)
                                    ? "No notes."
                                    : notes);

                            column.Item()
                                .PaddingTop(10)
                                .Text("Treatment Information")
                                .Bold();

                            column.Item()
                                .Text($"Treatment Type: {treatmentType}");

                            column.Item()
                                .Text($"Treatment Notes: {treatmentNotes}");

                            column.Item()
                                .Text($"Treatment Cost: {treatmentCost:C}");

                            column.Item()
                                .PaddingTop(10)
                                .Text("Payment Information")
                                .Bold();

                            column.Item()
                                .Text($"Payment Amount: {paymentAmount:C}");

                            column.Item()
                                .Text($"Payment Method: {paymentMethod}");

                            column.Item()
                                .Text($"Remaining Debt: {debt:C}")
                                .Bold();
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text($"Generated on {DateTime.Now:dd.MM.yyyy HH:mm}");
                });
            });

            return document.GeneratePdf();
        }
    }
}
