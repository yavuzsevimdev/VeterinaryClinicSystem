using System.Net;
using System.Net.Mail;

namespace VeterinaryClinic.API.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(
            string toEmail,
            string subject,
            string body,
            byte[] attachment,
            string attachmentName)
        {
            var smtpServer = _configuration["Email:SmtpServer"];
            var smtpPort = int.Parse(_configuration["Email:SmtpPort"]);
            var senderEmail = _configuration["Email:SenderEmail"];
            var senderPassword = _configuration["Email:SenderPassword"];

            using var message = new MailMessage();
            message.From = new MailAddress(senderEmail);
            message.To.Add(toEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = false;

            using var stream = new MemoryStream(attachment);
            var pdfAttachment = new Attachment(stream, attachmentName, "application/pdf");
            message.Attachments.Add(pdfAttachment);

            using var smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(
                senderEmail,
                senderPassword);

            await smtpClient.SendMailAsync(message);
        }
    }
}
