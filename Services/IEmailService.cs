using Api_Test.Models;

namespace Api_Test.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest request);
    }
}
