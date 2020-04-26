namespace Data.Interfaces.Repositories
{
    public interface IBookBorrowRepository
    {
        string RegisterBorrow(int bookId, string email);
        bool ConfirmLoan(string hash);
    }
}
