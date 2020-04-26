using Api.Controllers;
using Entities.Requests;
using Entities.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
        private readonly Mock<IBookBorrowService> _bookBorrowService;
        private readonly ApiController _controller;

        public ApiControllerTests()
        {
            _bookSearchServiceMock = new Mock<IBookSearchService>();
            _bookBorrowService = new Mock<IBookBorrowService>();
            _controller = new ApiController(_bookSearchServiceMock.Object, _bookBorrowService.Object);
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
            _bookBorrowService.Verify(mock => mock.BorrowBook(request.BookId, request.Email));
            _bookBorrowService.Verify(mock => mock.BorrowBook(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
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
            _bookBorrowService.Setup(mock => mock.BorrowBook(It.IsAny<int>(), It.IsAny<string>())).Throws(new Exception());
            var request = new BorrowBookRequest
            {
                BookId = _random.Next(),
                Email = $"{_random.Next()}@way2.com.br"
            };
            var expected = new JsonResult(new ErrorResponse(400, "falha ao finalizar empréstimo de livro"));
            var actual = _controller.BorrowBook(request);
            actual.Value.Should().Equals(expected.Value);
        }
    }
}