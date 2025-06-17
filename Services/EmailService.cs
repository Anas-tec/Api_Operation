using Api_Test.Models;
using System.Net;
using System.Net.Mail;

namespace Api_Test.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public EmailService(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            var emailSettings = _config.GetSection("EmailSettings");

            var templatePath = Path.Combine(_env.ContentRootPath, "Template", "ConfirmationTemplate.html");
            var htmlTemplate= await File.ReadAllTextAsync(templatePath);
            htmlTemplate = htmlTemplate
                .Replace("{{empName}}", request.Name ?? "User")
                .Replace("{{empEmail}}", request.ToEmail ?? "User@mail.com")
                .Replace("{{empPhone}}", request.Phone ?? "999999999");

            var smtpClient = new SmtpClient(emailSettings["SmtpServer"])
            {
                Port = int.Parse(emailSettings["Port"]),
                Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["SenderEmail"], emailSettings["SenderName"]),
                Subject = "confirmation mail",
                Body = htmlTemplate,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(request.ToEmail);

            //attachment part
            if (!string.IsNullOrEmpty(request.AttachmentPath)&&File.Exists(request.AttachmentPath)) 
            {
                var attachment = new Attachment(request.AttachmentPath);
                mailMessage.Attachments.Add(attachment);
            }

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
