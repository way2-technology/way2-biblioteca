using EASendMail;
using Microsoft.Extensions.Configuration;
using Services.Interfaces.Features.Common;

namespace Services.Features.Common
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(SmtpMail email)
        {

            var server = CreateServer();
            var client = new SmtpClient();
            client.SendMail(server, email);

        }

        private SmtpServer CreateServer() =>
            new SmtpServer(_configuration["AppSettings:smtpServer"])
            {
                User = _configuration["AppSettings:emailUser"],
                Password = _configuration["AppSettings:emailPassword"],
                Port = 587,
                ConnectType = SmtpConnectType.ConnectSSLAuto
            };
    }
}
