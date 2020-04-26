using Data.Interfaces.Helpers;
using Data.Interfaces.Repositories;
using System;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class BookBorrowRepository : IBookBorrowRepository
    {
        private readonly ISqlConnectionHelper _sqlConnectionHelper;

        public BookBorrowRepository(ISqlConnectionHelper sqlConnectionHelper)
        {
            _sqlConnectionHelper = sqlConnectionHelper;
        }

        public bool ConfirmLoan(string hash)
        {
            const string Sql = "update loan set isConfirmed = 1 where loanHash = @loanHash";
            using (var conn = _sqlConnectionHelper.CreateNewConnection())
            {
                try
                {
                    var cmd = new SqlCommand(Sql, conn);
                    cmd.Parameters.AddWithValue("@loanHash", hash);
                    conn.Open();
                    return (cmd.ExecuteNonQuery() == 1);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string RegisterBorrow(int bookId, string email)
        {
            const string Sql = @"insert into loan (book_id, loanDate, email, isConfirmed, loanHash) 
                                 values (@book_id, @loanDate, @email, @isConfirmed, @loanHash)";
            using (var conn = _sqlConnectionHelper.CreateNewConnection())
            {
                try
                {
                    var loanHash = Guid.NewGuid().ToString();
                    var cmd = new SqlCommand(Sql, conn);
                    cmd.Parameters.AddWithValue("@book_id", bookId);
                    cmd.Parameters.AddWithValue("@loanDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@isConfirmed", false);
                    cmd.Parameters.AddWithValue("@loanHash", loanHash);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return loanHash;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
