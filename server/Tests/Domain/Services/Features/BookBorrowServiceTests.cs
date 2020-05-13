using Data.Interfaces.Repositories;
using Entities.Entities;
using Moq;
using Services.Features.BorrowBook;
using Services.Interfaces.Features.BorrowBook;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Domain.Services.Features
{
    public class BookBorrowServiceTests
    {
        private readonly Random _random = new Random();
        private BookBorrowService _service;
        private readonly Mock<IBookBorrowRepository> _bookBorrowRepositoryMock;
        private readonly Mock<IEmailConfirmationService> _emailConfirmationServiceMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;

        public BookBorrowServiceTests()
        {
            _bookBorrowRepositoryMock = new Mock<IBookBorrowRepository>();
            _emailConfirmationServiceMock = new Mock<IEmailConfirmationService>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _service = new BookBorrowService(_bookBorrowRepositoryMock.Object, _emailConfirmationServiceMock.Object, _bookRepositoryMock.Object);
            _bookRepositoryMock.Setup(mock => mock.Load(It.IsAny<int>())).Returns(new Book());
        }

        [Fact]
        public void BorrowBook_should_register_borrow_on_database()
        {
            var bookId = _random.Next();
            var email = $"{_random.Next()}@way2.com.br";
            _service.BorrowBook(bookId, email);
            _bookBorrowRepositoryMock.Verify(mock => mock.RegisterBorrow(bookId, email));
            _bookBorrowRepositoryMock.Verify(mock => mock.RegisterBorrow(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void BorrowBook_should_send_email_confirmation()
        {
            var bookName = _random.Next().ToString();
            var bookId = _random.Next();
            var email = $"{_random.Next()}@way2.com.br";
            _service.BorrowBook(bookId, email);
            _emailConfirmationServiceMock.Verify(mock => mock.SendLoanConfirmationEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ReturnBook_should_get_borrows_from_user()
        {
            var email = $"{Guid.NewGuid()}@way2.com.br";
            _service.ReturnBook(email);

            _bookBorrowRepositoryMock.Verify(mock => mock.GetBorrows(email));
            _bookBorrowRepositoryMock.Verify(mock => mock.GetBorrows(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ReturnBook_should_call_email_confirmation_service_with_book_borrows()
        {
            var email = $"{Guid.NewGuid()}@way2.com.br";
            var bookBorrowList = new List<BookBorrow>();
            _bookBorrowRepositoryMock.Setup(mock => mock.GetBorrows(It.IsAny<string>())).Returns(bookBorrowList);
            _service.ReturnBook(email);

            _emailConfirmationServiceMock.Verify(mock => mock.SendLoanReturnEmail(email, bookBorrowList));
            _emailConfirmationServiceMock.Verify(mock => mock.SendLoanReturnEmail(It.IsAny<string>(), It.IsAny<IEnumerable< BookBorrow>>()), Times.Once);
        }
    }
}
