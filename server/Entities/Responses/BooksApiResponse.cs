using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Responses {
    public class BookCollectionApiResponse : PagedResult<BookApiResponse> {
        public BookCollectionApiResponse(IEnumerable<Book> books, int? currentPage, int? total) {
            Entity = books.Select(book => new BookApiResponse(book));
            CurrentPage = currentPage ?? 0;
            Total = total ?? 0;
        }
    }
}
