using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using VeterinaryClinic.Business.Dtos.ReportDtos;

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

        private void CreateReportStatCard(IContainer container, string title, string value, string color)
        {
            container
                .Background("#F8F7FC")
                .Border(1)
                .BorderColor("#E5E3EC")
                .CornerRadius(8)
                .Padding(12)
                .Column(column =>
                {
                    column.Item()
                        .Text(title)
                        .FontSize(9)
                        .FontColor("#7B7B90");

                    column.Item()
                        .PaddingTop(5)
                        .Text(value)
                        .FontSize(18)
                        .Bold()
                        .FontColor(color);
                });
        }

        private void CreateReportDetailRow(ColumnDescriptor column, string title, string value)
        {
            column.Item()
                .Row(row =>
                {
                    row.RelativeItem()
                        .Text(title)
                        .FontSize(10)
                        .FontColor("#7B7B90");

                    row.ConstantItem(100)
                        .AlignRight()
                        .Text(value)
                        .FontSize(10)
                        .Bold()
                        .FontColor("#303044");
                });
        }

        private void CreateStatusRow(ColumnDescriptor column, string title, int value, int total, string color)
        {
            var percentage =
                total == 0
                    ? 0
                    : (double)value / total * 100;

            var safePercentage = Math.Min(100, Math.Max(0, percentage));

            column.Item()
                .Row(row =>
                {
                    row.ConstantItem(80)
                        .Text(title)
                        .FontSize(9)
                        .FontColor("#7B7B90");

                    row.RelativeItem()
                        .PaddingHorizontal(10)
                        .Row(progress =>
                        {
                            if (safePercentage > 0)
                            {
                                progress.RelativeItem((float)safePercentage)
                                    .Height(8)
                                    .Background(color)
                                    .CornerRadius(4);
                            }

                            if (safePercentage < 100)
                            {
                                progress.RelativeItem((float)(100 - safePercentage))
                                    .Height(8)
                                    .Background("#EEEEF3")
                                    .CornerRadius(4);
                            }
                        });

                    row.ConstantItem(45)
                        .AlignRight()
                        .Text($"{percentage:0}%")
                        .FontSize(9)
                        .Bold()
                        .FontColor("#303044");
                });
        }
        public async Task<byte[]> GenerateDailyReportPdfAsync(DailyAppointmentReportDto report)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x =>
                        x.FontFamily("Arial")
                         .FontSize(10));

                    // =====================================================
                    // HEADER
                    // =====================================================

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Text("VETERİNER KLİNİĞİ")
                                .FontSize(20)
                                .Bold()
                                .FontColor("#6C63A8");

                            column.Item()
                                .PaddingTop(5)
                                .Text("Günlük Randevu Raporu")
                                .FontSize(14)
                                .Bold();

                            column.Item()
                                .PaddingTop(4)
                                .Text($"Rapor Tarihi: {report.Date:dd.MM.yyyy}")
                                .FontSize(10)
                                .FontColor("#7B7B90");

                            column.Item()
                                .PaddingTop(15)
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");
                        });


                    // =====================================================
                    // CONTENT
                    // =====================================================

                    page.Content()
                        .PaddingTop(25)
                        .Column(column =>
                        {
                            column.Spacing(15);

                            // -------------------------------------------------
                            // SUMMARY TITLE
                            // -------------------------------------------------

                            column.Item()
                                .Text("Randevu Özeti")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");


                            // -------------------------------------------------
                            // STATISTICS
                            // -------------------------------------------------

                            column.Item()
                                .Row(row =>
                                {
                                    row.Spacing(10);

                                    // TOTAL
                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Toplam Randevu",
                                                report.TotalAppointments.ToString(),
                                                "#6C63A8"
                                            )
                                        );

                                    // SCHEDULED
                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Planlandı",
                                                report.ScheduledAppointments.ToString(),
                                                "#7FAFD0"
                                            )
                                        );

                                    // COMPLETED
                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Tamamlandı",
                                                report.CompletedAppointments.ToString(),
                                                "#71B58A"
                                            )
                                        );

                                    // CANCELLED
                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "İptal",
                                                report.CancelledAppointments.ToString(),
                                                "#DF7C89"
                                            )
                                        );
                                });


                            // -------------------------------------------------
                            // DETAILS
                            // -------------------------------------------------

                            column.Item()
                                .PaddingTop(10)
                                .Text("Randevu Detayları")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");


                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(15)
                                .Column(details =>
                                {
                                    details.Spacing(10);

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Randevu",
                                        report.TotalAppointments.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Planlanan Randevu",
                                        report.ScheduledAppointments.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Tamamlanan Randevu",
                                        report.CompletedAppointments.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "İptal Edilen Randevu",
                                        report.CancelledAppointments.ToString()
                                    );
                                });


                            // -------------------------------------------------
                            // STATUS DISTRIBUTION
                            // -------------------------------------------------

                            column.Item()
                                .PaddingTop(10)
                                .Text("Durum Dağılımı")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");


                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(15)
                                .Column(status =>
                                {
                                    status.Spacing(12);

                                    CreateStatusRow(
                                        status,
                                        "Planlandı",
                                        report.ScheduledAppointments,
                                        report.TotalAppointments,
                                        "#7FAFD0"
                                    );

                                    CreateStatusRow(
                                        status,
                                        "Tamamlandı",
                                        report.CompletedAppointments,
                                        report.TotalAppointments,
                                        "#71B58A"
                                    );

                                    CreateStatusRow(
                                        status,
                                        "İptal",
                                        report.CancelledAppointments,
                                        report.TotalAppointments,
                                        "#DF7C89"
                                    );
                                });
                        });


                    // =====================================================
                    // FOOTER
                    // =====================================================

                    page.Footer()
                        .AlignCenter()
                        .Column(column =>
                        {
                            column.Item()
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");

                            column.Item()
                                .PaddingTop(8)
                                .Text(text =>
                                {
                                    text.Span("Veteriner Klinik Yönetim Sistemi • ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span("Sayfa ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.CurrentPageNumber()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span(" / ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.TotalPages()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");
                                });
                        });
                });
            });

            return await Task.FromResult(document.GeneratePdf());
        }

        public async Task<byte[]> GenerateMonthlyReportPdfAsync(MonthlyAppointmentReportDto report)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.DefaultTextStyle(x =>
                        x.FontFamily("Arial")
                         .FontSize(10));

                    // =====================================================
                    // HEADER
                    // =====================================================

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Text("VETERİNER KLİNİĞİ")
                                .FontSize(20)
                                .Bold()
                                .FontColor("#6C63A8");

                            column.Item()
                                .PaddingTop(5)
                                .Text("Aylık Randevu Raporu")
                                .FontSize(14)
                                .Bold();

                            column.Item()
                                .PaddingTop(4)
                                .Text($"Rapor Dönemi: {report.Date:MMMM yyyy}")
                                .FontSize(10)
                                .FontColor("#7B7B90");

                            column.Item()
                                .PaddingTop(15)
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");
                        });


                    // =====================================================
                    // CONTENT
                    // =====================================================

                    page.Content()
                        .PaddingTop(25)
                        .Column(column =>
                        {
                            column.Spacing(15);

                            // -------------------------------------------------
                            // SUMMARY TITLE
                            // -------------------------------------------------

                            column.Item()
                                .Text("Randevu Özeti")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");


                            // -------------------------------------------------
                            // STATISTICS
                            // -------------------------------------------------

                            column.Item()
                                .Row(row =>
                                {
                                    row.Spacing(10);

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Toplam Randevu",
                                                report.TotalAppointments.ToString(),
                                                "#6C63A8"
                                            ));

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Planlandı",
                                                report.ScheduledAppointments.ToString(),
                                                "#7FAFD0"
                                            ));

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Tamamlandı",
                                                report.CompletedAppointments.ToString(),
                                                "#71B58A"
                                            ));

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "İptal",
                                                report.CancelledAppointments.ToString(),
                                                "#DF7C89"
                                            ));
                                });


                            // -------------------------------------------------
                            // DETAILS
                            // -------------------------------------------------

                            column.Item()
                                .PaddingTop(10)
                                .Text("Aylık Randevu Detayları")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");

                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(15)
                                .Column(details =>
                                {
                                    details.Spacing(10);

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Randevu",
                                        report.TotalAppointments.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Planlanan Randevu",
                                        report.ScheduledAppointments.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Tamamlanan Randevu",
                                        report.CompletedAppointments.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "İptal Edilen Randevu",
                                        report.CancelledAppointments.ToString()
                                    );
                                });


                            // -------------------------------------------------
                            // STATUS DISTRIBUTION
                            // -------------------------------------------------

                            column.Item()
                                .PaddingTop(10)
                                .Text("Durum Dağılımı")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");

                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(15)
                                .Column(status =>
                                {
                                    status.Spacing(12);

                                    CreateStatusRow(
                                        status,
                                        "Planlandı",
                                        report.ScheduledAppointments,
                                        report.TotalAppointments,
                                        "#7FAFD0"
                                    );

                                    CreateStatusRow(
                                        status,
                                        "Tamamlandı",
                                        report.CompletedAppointments,
                                        report.TotalAppointments,
                                        "#71B58A"
                                    );

                                    CreateStatusRow(
                                        status,
                                        "İptal",
                                        report.CancelledAppointments,
                                        report.TotalAppointments,
                                        "#DF7C89"
                                    );
                                });
                        });


                    // =====================================================
                    // FOOTER
                    // =====================================================

                    page.Footer()
                        .AlignCenter()
                        .Column(column =>
                        {
                            column.Item()
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");

                            column.Item()
                                .PaddingTop(8)
                                .Text(text =>
                                {
                                    text.Span("Veteriner Klinik Yönetim Sistemi • ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span("Sayfa ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.CurrentPageNumber()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span(" / ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.TotalPages()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");
                                });
                        });
                });
            });

            return await Task.FromResult(document.GeneratePdf());
        }
        
        public async Task<byte[]> GenerateFinancialReportPdfAsync(FinancialReportDto report)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.DefaultTextStyle(x =>
                        x.FontFamily("Arial")
                         .FontSize(10));

                    // =====================================================
                    // HEADER
                    // =====================================================

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Text("VETERİNER KLİNİĞİ")
                                .FontSize(20)
                                .Bold()
                                .FontColor("#6C63A8");

                            column.Item()
                                .PaddingTop(5)
                                .Text("Finansal Rapor")
                                .FontSize(14)
                                .Bold();

                            column.Item()
                                .PaddingTop(4)
                                .Text(
                                    $"Rapor Dönemi: {report.StartDate:dd.MM.yyyy} - {report.EndDate:dd.MM.yyyy}")
                                .FontSize(10)
                                .FontColor("#7B7B90");

                            column.Item()
                                .PaddingTop(15)
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");
                        });


                    // =====================================================
                    // CONTENT
                    // =====================================================

                    page.Content()
                        .PaddingTop(25)
                        .Column(column =>
                        {
                            column.Spacing(15);

                            // -------------------------------------------------
                            // SUMMARY
                            // -------------------------------------------------

                            column.Item()
                                .Text("Finansal Özet")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");


                            column.Item()
                                .Row(row =>
                                {
                                    row.Spacing(10);

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Toplam Tedavi",
                                                $"{report.TotalTreatmentCost:N2} ₺",
                                                "#6C63A8"
                                            ));

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Toplam Tahsilat",
                                                $"{report.TotalPaid:N2} ₺",
                                                "#71B58A"
                                            ));

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Toplam Borç",
                                                $"{report.TotalDebt:N2} ₺",
                                                "#DF7C89"
                                            ));
                                });


                            // -------------------------------------------------
                            // DETAILS
                            // -------------------------------------------------

                            column.Item()
                                .PaddingTop(10)
                                .Text("Finansal Detaylar")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");


                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(15)
                                .Column(details =>
                                {
                                    details.Spacing(10);

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Tedavi Tutarı",
                                        $"{report.TotalTreatmentCost:N2} ₺"
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Tahsilat",
                                        $"{report.TotalPaid:N2} ₺"
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Borç",
                                        $"{report.TotalDebt:N2} ₺"
                                    );
                                });


                            // -------------------------------------------------
                            // COLLECTION / DEBT
                            // -------------------------------------------------

                            var collectionPercentage =
                                report.TotalTreatmentCost == 0
                                    ? 0
                                    : (double)(report.TotalPaid /
                                               report.TotalTreatmentCost) * 100;

                            collectionPercentage =
                                Math.Min(100, Math.Max(0, collectionPercentage));

                            column.Item()
                                .PaddingTop(10)
                                .Text("Tahsilat Durumu")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");


                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(15)
                                .Column(status =>
                                {
                                    status.Spacing(12);

                                    status.Item()
                                        .Row(row =>
                                        {
                                            row.ConstantItem(100)
                                                .Text("Tahsilat Oranı")
                                                .FontSize(9)
                                                .FontColor("#7B7B90");

                                            row.RelativeItem()
                                                .PaddingHorizontal(10)
                                                .Row(progress =>
                                                {
                                                    if (collectionPercentage > 0)
                                                    {
                                                        progress
                                                            .RelativeItem(
                                                                (float)collectionPercentage)
                                                            .Height(8)
                                                            .Background("#71B58A")
                                                            .CornerRadius(4);
                                                    }

                                                    if (collectionPercentage < 100)
                                                    {
                                                        progress
                                                            .RelativeItem(
                                                                (float)(100 -
                                                                    collectionPercentage))
                                                            .Height(8)
                                                            .Background("#EEEEF3")
                                                            .CornerRadius(4);
                                                    }
                                                });

                                            row.ConstantItem(45)
                                                .AlignRight()
                                                .Text($"{collectionPercentage:0}%")
                                                .FontSize(9)
                                                .Bold()
                                                .FontColor("#303044");
                                        });

                                    CreateReportDetailRow(
                                        status,
                                        "Tahsil Edilen",
                                        $"{report.TotalPaid:N2} ₺"
                                    );

                                    CreateReportDetailRow(
                                        status,
                                        "Kalan Borç",
                                        $"{report.TotalDebt:N2} ₺"
                                    );
                                });
                        });


                    // =====================================================
                    // FOOTER
                    // =====================================================

                    page.Footer()
                        .AlignCenter()
                        .Column(column =>
                        {
                            column.Item()
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");

                            column.Item()
                                .PaddingTop(8)
                                .Text(text =>
                                {
                                    text.Span("Veteriner Klinik Yönetim Sistemi • ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span("Sayfa ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.CurrentPageNumber()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span(" / ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.TotalPages()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");
                                });
                        });
                });
            });

            return await Task.FromResult(document.GeneratePdf());
        }

        public async Task<byte[]> GenerateAnimalTreatmentReportPdfAsync(List<AnimalTreatmentHistoryDto> treatments)
        {
            var totalAnimals = treatments
                .Select(x => x.AnimalId)
                .Distinct()
                .Count();

            var totalTreatments = treatments.Count;

            var totalCost = treatments.Sum(x => x.Cost);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.DefaultTextStyle(x =>
                        x.FontFamily("Arial")
                         .FontSize(10));

                    // =====================================================
                    // HEADER
                    // =====================================================

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Text("VETERİNER KLİNİĞİ")
                                .FontSize(20)
                                .Bold()
                                .FontColor("#6C63A8");

                            column.Item()
                                .PaddingTop(5)
                                .Text("Hayvan Tedavi Raporu")
                                .FontSize(14)
                                .Bold();

                            column.Item()
                                .PaddingTop(4)
                                .Text("Hayvan bazlı tedavi geçmişi ve sağlık bilgileri")
                                .FontSize(10)
                                .FontColor("#7B7B90");

                            column.Item()
                                .PaddingTop(15)
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");
                        });


                    // =====================================================
                    // CONTENT
                    // =====================================================

                    page.Content()
                        .PaddingTop(25)
                        .Column(column =>
                        {
                            column.Spacing(15);

                            column.Item()
                                .Text("Tedavi Özeti")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");

                            // -------------------------------------------------
                            // STATISTICS
                            // -------------------------------------------------

                            column.Item()
                                .Row(row =>
                                {
                                    row.Spacing(10);

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Toplam Hayvan",
                                                totalAnimals.ToString(),
                                                "#6C63A8"
                                            ));

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Toplam Tedavi",
                                                totalTreatments.ToString(),
                                                "#7FAFD0"
                                            ));

                                    row.RelativeItem()
                                        .Element(container =>
                                            CreateReportStatCard(
                                                container,
                                                "Tedavi Maliyeti",
                                                $"{totalCost:N2} ₺",
                                                "#71B58A"
                                            ));
                                });


                            // -------------------------------------------------
                            // DETAILS
                            // -------------------------------------------------

                            column.Item()
                                .PaddingTop(10)
                                .Text("Tedavi Detayları")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");

                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(15)
                                .Column(details =>
                                {
                                    details.Spacing(10);

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Hayvan",
                                        totalAnimals.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Tedavi",
                                        totalTreatments.ToString()
                                    );

                                    CreateReportDetailRow(
                                        details,
                                        "Toplam Tedavi Maliyeti",
                                        $"{totalCost:N2} ₺"
                                    );
                                });


                            // -------------------------------------------------
                            // TREATMENT LIST
                            // -------------------------------------------------

                            column.Item()
                                .PaddingTop(10)
                                .Text("Tedavi Geçmişi")
                                .FontSize(13)
                                .Bold()
                                .FontColor("#303044");

                            column.Item()
                                .Border(1)
                                .BorderColor("#E5E3EC")
                                .CornerRadius(8)
                                .Padding(12)
                                .Column(history =>
                                {
                                    history.Spacing(8);

                                    foreach (var item in treatments
                                        .OrderByDescending(x => x.AppointmentDate))
                                    {
                                        history.Item()
                                            .Row(row =>
                                            {
                                                row.RelativeItem()
                                                    .Column(info =>
                                                    {
                                                        info.Item()
                                                            .Text(item.AnimalName)
                                                            .Bold()
                                                            .FontSize(10)
                                                            .FontColor("#303044");

                                                        info.Item()
                                                            .PaddingTop(2)
                                                            .Text(item.TreatmentType)
                                                            .FontSize(9)
                                                            .FontColor("#7B7B90");

                                                        info.Item()
                                                            .PaddingTop(2)
                                                            .Text(
                                                                $"{item.AppointmentDate:dd.MM.yyyy} • " +
                                                                $"{item.Notes}")
                                                            .FontSize(8)
                                                            .FontColor("#7B7B90");
                                                    });

                                                row.ConstantItem(90)
                                                    .AlignRight()
                                                    .Text($"{item.Cost:N2} ₺")
                                                    .Bold()
                                                    .FontSize(10)
                                                    .FontColor("#6C63A8");
                                            });
                                    }
                                });
                        });


                    // =====================================================
                    // FOOTER
                    // =====================================================

                    page.Footer()
                        .AlignCenter()
                        .Column(column =>
                        {
                            column.Item()
                                .LineHorizontal(1)
                                .LineColor("#E5E3EC");

                            column.Item()
                                .PaddingTop(8)
                                .Text(text =>
                                {
                                    text.Span("Veteriner Klinik Yönetim Sistemi • ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span("Sayfa ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.CurrentPageNumber()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.Span(" / ")
                                        .FontSize(8)
                                        .FontColor("#7B7B90");

                                    text.TotalPages()
                                        .FontSize(8)
                                        .FontColor("#7B7B90");
                                });
                        });
                });
            });

            return await Task.FromResult(document.GeneratePdf());
        }
    }
}
