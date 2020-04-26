using Data.Interfaces.Repositories;
using Services.Interfaces.Features.BorrowBook;
using System;

namespace Services.Features.BorrowBook
{
    public class BookBorrowService : IBookBorrowService
    {
        private readonly IBookBorrowRepository _bookBorrowRepository;
        private readonly IEmailConfirmationService _emailConfirmationService;
        private readonly IBookRepository _bookRepository;
        

        public BookBorrowService(IBookBorrowRepository bookBorrowRepository, IEmailConfirmationService emailConfirmationService, IBookRepository bookRepository)
        {
            _bookBorrowRepository = bookBorrowRepository;
            _emailConfirmationService = emailConfirmationService;
            _bookRepository = bookRepository;
        }

        public void BorrowBook(int bookId, string email)
        {
            var hash = _bookBorrowRepository.RegisterBorrow(bookId, email);
            var book = _bookRepository.Load(bookId);
            if (book == null)
            {
                throw new ArgumentException(nameof(bookId));
            }
            _emailConfirmationService.SendEmail(email, book.Title, hash);
        }

        public bool ValidateLoan(string hash) =>
            _bookBorrowRepository.ConfirmLoan(hash);
    }
}
