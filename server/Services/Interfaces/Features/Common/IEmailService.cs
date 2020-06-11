using EASendMail;

namespace Services.Interfaces.Features.Common
{
    public interface IEmailService
    {
        void SendEmail(SmtpMail email);
    }
}
