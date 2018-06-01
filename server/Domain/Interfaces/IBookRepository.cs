using System.Collections.Generic;
using Domain.Responses;

namespace Domain.Interfaces {
    public interface IBookRepository {
        IEnumerable<Book> ListAll();
        IEnumerable<Book> Search(int skip, int take, string keyword);
    }
}
