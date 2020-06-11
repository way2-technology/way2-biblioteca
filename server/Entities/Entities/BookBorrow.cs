using System;

namespace Entities.Entities
{
    public class BookBorrow
    {
        public string Title { get; set; }
        public string LoanHash { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
