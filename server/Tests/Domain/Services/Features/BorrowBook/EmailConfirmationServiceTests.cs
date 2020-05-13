using EASendMail;
using Entities.Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using Services.Features.BorrowBook;
using Services.Interfaces.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.Domain.Services.Features.BorrowBook
{
    public class EmailConfirmationServiceTests
    {
        private EmailConfirmationService _emailConfirmationService;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IEmailService> _emailServiceMock;

        public EmailConfirmationServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _emailServiceMock = new Mock<IEmailService>();
            _emailConfirmationService = new EmailConfirmationService(_configurationMock.Object, _emailServiceMock.Object);
        }

        [Fact]
        public void SendLoanConfirmationEmail_should_send_loan_confirmation_email_with_expected_body()
        {
            var bookName = Guid.NewGuid().ToString();
            var hash = Guid.NewGuid().ToString();
            var confirmationUrl = $"{Guid.NewGuid()}/{hash}";
            _configurationMock.Setup(mock => mock["AppSettings:loanConfirmationUrl"]).Returns(confirmationUrl);
            var emailBodyExpected = new StringBuilder()
                .Append("<p>Olá humano(a), </p>")
                .Append($"<p>Obrigado por solicitar o empréstimo do livro '{bookName}'. Estamos quase lá, só precisamos que você confirme a sua solicitação clicando no link abaixo:</p>")
                .Append($"<a href=\"{confirmationUrl}\">Confirmar empréstimo</a>")
                .Append("<p>ou acessando essa URL de confirmação:</p>")
                .Append($"<p>{confirmationUrl}</p>")
                .Append("<p>Agradecemos o interesse em ampliar seus conhecimentos e desejamos uma boa leitura =]</p>")
                .Append("<p><strong>Way2Library(beta)</strong></p>");
            _emailConfirmationService.SendLoanConfirmationEmail(Guid.NewGuid().ToString(), bookName, hash);
            _emailServiceMock.Verify(mock => mock.SendEmail(It.Is<SmtpMail>(mail => mail.HtmlBody.Equals(emailBodyExpected.ToString()))));
        }

        [Fact]
        public void SendLoanConfirmationEmail_should_send_email()
        {
            var bookName = Guid.NewGuid().ToString();
            var hash = Guid.NewGuid().ToString();
            var confirmationUrl = $"{Guid.NewGuid()}/{hash}";
            var emailAddress = Guid.NewGuid().ToString();
            _configurationMock.Setup(mock => mock["AppSettings:loanConfirmationUrl"]).Returns(confirmationUrl);
            var expectedEmail = new SmtpMail("TryIt")
            {
                From = "noreply@way2.com.br",
                Cc = "thiagocerutti@gmail.com",
                To = emailAddress,
                Subject = "Way2Library - Empréstimo de livro",
            };

            _emailConfirmationService.SendLoanConfirmationEmail(emailAddress, bookName, hash);
            _emailServiceMock.Verify(mock => mock.SendEmail(It.Is<SmtpMail>(mail =>
                mail.From.ToString() == expectedEmail.From.ToString() &&
                mail.Cc.ToString() == expectedEmail.Cc.ToString() &&
                mail.To.ToString() == expectedEmail.To.ToString() &&
                mail.Subject.ToString() == expectedEmail.Subject.ToString()
            )));
        }

        [Fact]
        public void SendLoanReturnEmail_should_send_no_book_borrowed_email()
        {
            var emailHtmlBodyExpected = "<p>Olá humano(a), </p>" +
                $"<p>Você não tem livros emprestados. São eles:</p>" +
                "<p>Que tal escolher sua próxima leitura <a href=\"https://w2lib.azurewebsites.net/\">aqui?<a> :)</p>";
            var emailAddress = Guid.NewGuid().ToString();
            var expectedEmail = new SmtpMail("TryIt")
            {
                From = "noreply@way2.com.br",
                Cc = "thiagocerutti@gmail.com",
                To = emailAddress,
                Subject = "Way2Library - Devolução de livro",
            };
            _emailConfirmationService.SendLoanReturnEmail(emailAddress, new List<BookBorrow>());
            _emailServiceMock.Verify(mock => mock.SendEmail(It.Is<SmtpMail>(mail =>
                mail.From.ToString() == expectedEmail.From.ToString() &&
                mail.Cc.ToString() == expectedEmail.Cc.ToString() &&
                mail.To.ToString() == expectedEmail.To.ToString() &&
                mail.Subject == expectedEmail.Subject.ToString() &&
                mail.HtmlBody == emailHtmlBodyExpected
            )));
        }

        [Fact]
        public void SendLoanReturnEmail_should_send_books_borrowed_email()
        {
            var confirmationUrl = Guid.NewGuid().ToString() + "/{0}";
            _configurationMock.Setup(mock => mock["AppSettings:loanConfirmationUrl"]).Returns(confirmationUrl);
            var bookBorrowsList = new List<BookBorrow>
            {
                new BookBorrow
                {
                    LoanDate = new DateTime(2020, 5, 11, 22, 24, 00),
                    LoanHash = Guid.NewGuid().ToString(),
                    Title = Guid.NewGuid().ToString()
                },
                new BookBorrow
                {
                    LoanDate = new DateTime(2020, 5, 11, 22, 24, 00),
                    LoanHash = Guid.NewGuid().ToString(),
                    Title = Guid.NewGuid().ToString()
                },
            };
            var emailHtmlBodyExpected = new StringBuilder()
                .Append("<p>Olá humano(a), </p>")
                .Append($"<p>Você tem {bookBorrowsList.Count()} livro(s) emprestado(s). São eles:</p>");

            bookBorrowsList.Select(book => emailHtmlBodyExpected.Append($"<p><a href=\"{GetReturnBookUrl(book.LoanHash)}\">{book.Title}</a></p>"));

            emailHtmlBodyExpected.Append("<p>Clique no link do respectivo empréstimo para devolver o livro. Espramos que tenha aproveitado a leitura!</p>")
                .Append("<p>E que tal dar uma olhada nos <a href=\"https://w2lib.azurewebsites.net/\">nossos outros livros?<a> :)</p>")
                .Append("<p><strong>Way2Library (beta)</strong></p>");
            var emailAddress = Guid.NewGuid().ToString();
            var expectedEmail = new SmtpMail("TryIt")
            {
                From = "noreply@way2.com.br",
                Cc = "thiagocerutti@gmail.com",
                To = emailAddress,
                Subject = "Way2Library - Devolução de livro",
                HtmlBody = emailHtmlBodyExpected.ToString()
            };
            _emailConfirmationService.SendLoanReturnEmail(emailAddress, bookBorrowsList);
            _emailServiceMock.Verify(mock => mock.SendEmail(It.Is<SmtpMail>(mail =>
                mail.From.ToString() == expectedEmail.From.ToString() &&
                mail.Cc.ToString() == expectedEmail.Cc.ToString() &&
                mail.To.ToString() == expectedEmail.To.ToString() &&
                mail.Subject == expectedEmail.Subject.ToString() &&
                mail.HtmlBody == expectedEmail.HtmlBody
            )));
        }

        private string GetReturnBookUrl(string hash) =>
            string.Format(_configurationMock.Object["AppSettings:loanConfirmationUrl"], hash);
    }
}
