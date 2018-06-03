using System.Collections.Generic;
using Domain.Responses;

namespace Domain.Interfaces {
    public interface IBookRepository {
        IEnumerable<Book> ListAll(int skip, int take);
        IEnumerable<Book> Search(string keyword, int skip, int take);
    }
}
