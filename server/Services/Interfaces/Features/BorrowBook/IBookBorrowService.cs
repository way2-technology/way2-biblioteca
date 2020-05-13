namespace Services.Interfaces.Features.BorrowBook
{
    public interface IBookBorrowService
    {
        void BorrowBook(int bookId, string email);
        bool ValidateLoan(string hash);
        void ReturnBook(string email);
    }
}
