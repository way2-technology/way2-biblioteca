using EASendMail;
using Entities.Entities;
using Microsoft.Extensions.Configuration;
using Services.Interfaces.Features.BorrowBook;
using Services.Interfaces.Features.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Features.BorrowBook
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;


        public EmailConfirmationService(IConfiguration configuration, IEmailService emailService)
        {
            _configuration = configuration;
            _emailService = emailService;
        }

        public void SendLoanConfirmationEmail(string emailAddress, string bookName, string hash)
        {
            var confirmationUrl = string.Format(_configuration["AppSettings:loanConfirmationUrl"], hash);
            var emailHtmlBody = new StringBuilder()
                .Append("<p>Olá humano(a), </p>")
                .Append($"<p>Obrigado por solicitar o empréstimo do livro '{bookName}'. Estamos quase lá, só precisamos que você confirme a sua solicitação clicando no link abaixo:</p>")
                .Append($"<a href=\"{confirmationUrl}\">Confirmar empréstimo</a>")
                .Append("<p>ou acessando essa URL de confirmação:</p>")
                .Append($"<p>{confirmationUrl}</p>")
                .Append("<p>Agradecemos o interesse em ampliar seus conhecimentos e desejamos uma boa leitura =]</p>")
                .Append("<p><strong>Way2Library(beta)</strong></p>");
            var email = CreateEmail("noreply@way2.com.br", emailAddress, "Way2Library - Empréstimo de livro", emailHtmlBody.ToString());
            SendEmail(email);
        }

        public void SendLoanReturnEmail(string emailAddress, IEnumerable<BookBorrow> bookBorrows)
        {
            var email = CreateReturnEmail(emailAddress, bookBorrows);
            SendEmail(email);
        }

        private SmtpMail CreateReturnEmail(string emailAddress, IEnumerable<BookBorrow> bookBorrows)
        {
            var emailHtmlBody = bookBorrows.Any() ?
                CreateHtmlBodyForBorrowedBooks(bookBorrows) :
                CreateHtmlBodyForNoBorrowedBooks();
            return CreateEmail("noreply@way2.com.br", emailAddress, "Way2Library - Devolução de livro", emailHtmlBody);
        }

        private string CreateHtmlBodyForNoBorrowedBooks() =>
            "<p>Olá humano(a), </p>" +
                $"<p>Você não tem livros emprestados. São eles:</p>" +
                "<p>Que tal escolher sua próxima leitura <a href=\"https://w2lib.azurewebsites.net/\">aqui?<a> :)</p>";
        
        private string CreateHtmlBodyForBorrowedBooks(IEnumerable<BookBorrow> bookBorrows)
        {
            var emailHtmlBody = new StringBuilder();
            emailHtmlBody.Append("<p>Olá humano(a), </p>")
                .Append($"<p>Você tem {bookBorrows.Count()} livro(s) emprestado(s). São eles:</p>");

            bookBorrows.Select(book => emailHtmlBody.Append($"<p><a href=\"{GetReturnBookUrl(book.LoanHash)}\">{book.Title}</a></p>"));

            return emailHtmlBody.Append("<p>Clique no link do respectivo empréstimo para devolver o livro. Espramos que tenha aproveitado a leitura!</p>")
                .Append("<p>E que tal dar uma olhada nos <a href=\"https://w2lib.azurewebsites.net/\">nossos outros livros?<a> :)</p>")
                .Append("<p><strong>Way2Library (beta)</strong></p>").ToString();
        }

        public string GetReturnBookUrl(string hash) =>
            string.Format(_configuration["AppSettings:loanConfirmationUrl"], hash);

        private void SendEmail(SmtpMail email) =>
            _emailService.SendEmail(email);


        private SmtpMail CreateEmail(string senderEmailAddress, string destinationEmailAddress, string emailTitle, string emailHtmlBody) =>
            new SmtpMail("TryIt")
            {
                From = senderEmailAddress,
                Cc = "thiagocerutti@gmail.com",
                To = destinationEmailAddress,
                Subject = emailTitle,
                HtmlBody = emailHtmlBody,
            };
    }
}
