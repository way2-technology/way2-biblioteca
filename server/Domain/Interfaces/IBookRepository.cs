using System.Collections.Generic;
using Domain.Responses;

namespace Domain.Interfaces {
    public interface IBookRepository
    {
        IEnumerable<Book> ListAll();
    }
}
