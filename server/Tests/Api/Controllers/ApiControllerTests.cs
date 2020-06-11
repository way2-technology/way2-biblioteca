using Api.Controllers;
using Entities.Requests;
using Entities.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using Services.Interfaces.Features.BorrowBook;
using Services.Interfaces.Features.Search;
using System;
using Xunit;

namespace Tests.Api.Controllers
{

    public class ApiControllerTests
    {
        private Random _random = new Random();
        private readonly Mock<IBookSearchService> _bookSearchServiceMock;
        private readonly Mock<IBookBorrowService> _bookBorrowServiceMock;
        private readonly ApiController _controller;

        public ApiControllerTests()
        {
            _bookSearchServiceMock = new Mock<IBookSearchService>();
            _bookBorrowServiceMock = new Mock<IBookBorrowService>();
            _controller = new ApiController(_bookSearchServiceMock.Object, _bookBorrowServiceMock.Object);
        }

        [Fact]
        public void BorrowBook_should_validate_email_domain()
        {
            var expected = new JsonResult(new ErrorResponse(400, "Invalid email domain"));
            var actual = _controller.BorrowBook(new BorrowBookRequest { BookId = 1, Email = "name@gmail.com" });
            actual.Value.Should().Equals(expected.Value);
        }

        [Fact]
        public void BorrowBook_should_call_book_loan_service()
        {
            var request = new BorrowBookRequest
            {
                BookId = _random.Next(),
                Email = $"{_random.Next()}@way2.com.br"
            };

            _controller.BorrowBook(request);
            _bookBorrowServiceMock.Verify(mock => mock.BorrowBook(request.BookId, request.Email));
            _bookBorrowServiceMock.Verify(mock => mock.BorrowBook(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void BorrowBook_should_return_success()
        {
            var request = new BorrowBookRequest
            {
                BookId = _random.Next(),
                Email = $"{_random.Next()}@way2.com.br"
            };
            var expected = new JsonResult("ok");
            var actual = _controller.BorrowBook(request);
            actual.Value.Should().Equals(expected.Value);
        }

        [Fact]
        public void BorrowBook_should_return_failure()
        {
            _bookBorrowServiceMock.Setup(mock => mock.BorrowBook(It.IsAny<int>(), It.IsAny<string>())).Throws(new Exception());
            var request = new BorrowBookRequest
            {
                BookId = _random.Next(),
                Email = $"{_random.Next()}@way2.com.br"
            };
            var expected = new JsonResult(new ErrorResponse(400, "falha ao finalizar empréstimo de livro"));
            var actual = _controller.BorrowBook(request);
            actual.Value.Should().Equals(expected.Value);
        }

        [Fact]
        public void RequestReturnBook_should_validate_email()
        {
            var emailInvalido = Guid.NewGuid().ToString();
            var expected = new JsonResult(new ErrorResponse(400, "Domínio de email inválido"));
            var actual = _controller.RequestReturnBook(emailInvalido);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void RequestReturnBook_should_call_return_book_service()
        {
            var email = "somebody@way2.com.br";
            _controller.RequestReturnBook(email);
            _bookBorrowServiceMock.Verify(mock => mock.SendReturnBookEmail(email));
            _bookBorrowServiceMock.Verify(mock => mock.SendReturnBookEmail(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void RequestReturnBook_should_return_success_message()
        {
            var email = "somebody@way2.com.br";
            var expected = new JsonResult("Instruções de devolução foram enviadas para o seu email");
            var actual = _controller.RequestReturnBook(email);
            actual.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void RequestReturnBook_should_return_error_message()
        {
            var email = "somebody@way2.com.br";
            var exception = new Exception(Guid.NewGuid().ToString());
            _bookBorrowServiceMock.Setup(mock => mock.SendReturnBookEmail(It.IsAny<string>())).Throws(exception);
            var expected = new JsonResult(new ErrorResponse(400, $"falha ao finalizar empréstimo de livro: {exception.Message}"));
            var actual = _controller.RequestReturnBook(email);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}