using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Responses {
    public class BookCollectionApiResponse : PagedResult<BookApiResponse> {
        public BookCollectionApiResponse(IEnumerable<Book> books, int? currentPage, int? count) {
            Entity = books.Select(book => new BookApiResponse(book));
            CurrentPage = currentPage ?? 0;
            TotalCount = count ?? 0;
        }
    }
}
