using Entities.Entities;
using System.Collections.Generic;

namespace Data.Interfaces.Repositories
{
    public interface IBookBorrowRepository
    {
        string RegisterBorrow(int bookId, string emailAddress);
        bool ConfirmLoan(string hash);
        IEnumerable<BookBorrow> GetBorrows(string emailAddress);
    }
}
