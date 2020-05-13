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

        public void BorrowBook(int bookId, string emailAddress)
        {
            var hash = _bookBorrowRepository.RegisterBorrow(bookId, emailAddress);
            var book = _bookRepository.Load(bookId);
            if (book == null)
            {
                throw new ArgumentException(nameof(bookId));
            }
            _emailConfirmationService.SendLoanConfirmationEmail(emailAddress, book.Title, hash);
        }

        public void ReturnBook(string emailAddress)
        {
            var bookBorrows = _bookBorrowRepository.GetBorrows(emailAddress);
            _emailConfirmationService.SendLoanReturnEmail(emailAddress, bookBorrows);
        }

        public bool ValidateLoan(string hash) =>
            _bookBorrowRepository.ConfirmLoan(hash);
    }
}
