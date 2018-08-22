using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Services.Search {
    public interface IBookSearchService {
        IEnumerable<Book> Search(string keyword, int skip, int take);
        IEnumerable<Book> ListAll(int skip, int take);
        Book FindById(int id);
    }
}
