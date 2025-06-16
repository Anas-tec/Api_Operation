using Api_Test.Models;
using System.Net;
using System.Net.Mail;

namespace Api_Test.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            var emailSettings = _config.GetSection("EmailSettings");

            var smtpClient = new SmtpClient(emailSettings["SmtpServer"])
            {
                Port = int.Parse(emailSettings["Port"]),
                Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["SenderEmail"], emailSettings["SenderName"]),
                Subject = request.Subject,
                Body = request.Body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(request.ToEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
