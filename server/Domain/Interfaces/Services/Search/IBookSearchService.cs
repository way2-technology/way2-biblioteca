using System.Collections.Generic;
using Domain.Responses;

namespace Domain.Interfaces.Services.Search {
    public interface IBookSearchService {
        IEnumerable<Book> Search(string keyword, int skip, int take);
        IEnumerable<Book> ListAll(int skip, int take);
    }
}
