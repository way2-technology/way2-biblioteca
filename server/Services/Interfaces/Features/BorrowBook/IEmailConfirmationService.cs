namespace Services.Interfaces.Features.BorrowBook
{
    public interface IEmailConfirmationService
    {
        void SendEmail(string email, string bookName, string hash);
    }
}
