using Entities.Entities;
using System.Collections.Generic;

namespace Services.Interfaces.Features.BorrowBook
{
    public interface IEmailConfirmationService
    {
        void SendLoanConfirmationEmail(string email, string bookName, string hash);
        void SendLoanReturnEmail(string emailAddress, IEnumerable<BookBorrow> bookBorrows);
    }
}
