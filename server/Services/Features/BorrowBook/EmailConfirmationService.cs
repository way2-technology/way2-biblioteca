using EASendMail;
using Microsoft.Extensions.Configuration;
using Services.Interfaces.Features.BorrowBook;

namespace Services.Features.BorrowBook
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly IConfiguration _configuration;

        public EmailConfirmationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string emailAddress, string bookName, string hash)
        {
            var confirmationUrl = string.Format(_configuration["AppSettings:loanConfirmationUrl"], hash);
            var email = new SmtpMail("TryIt")
            {
                From = "noreply@way2.com.br",
                To = emailAddress,
                Subject = "Way2Library - Empréstimo de livro",
                HtmlBody =
                    "<p>Olá humano(a), </p>" +
                    $"<p>Obrigado por solicitar o empréstimo do livro '{bookName}'. Estamos quase lá, só precisamos que você confirme a sua solicitação clicando no link abaixo:</p>" +
                    $"<a href=\"{confirmationUrl}\">Confirmar empréstimo</a>" +
                    "<p>ou acessando essa URL de confirmação:</p>" +
                    $"<p>{confirmationUrl}</p>" +
                    "<p>Agradecemos o interesse em ampliar seus conhecimentos e desejamos uma boa leitura =]</p>" +
                    "<p><strong>Way2Library(beta)</strong></p> ",
            };

            var server = new SmtpServer("smtp.gmail.com")
            {
                User = _configuration["AppSettings:emailUser"],
                Password = _configuration["AppSettings:emailPassword"],
                Port = 587,
                ConnectType = SmtpConnectType.ConnectSSLAuto
            };

            var client = new SmtpClient();
            client.SendMail(server, email);
        }
    }
}
