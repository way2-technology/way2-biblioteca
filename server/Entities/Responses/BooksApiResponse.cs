using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Responses {
    public class BookCollectionApiResponse : PagedResult<BookApiResponse> {
        public BookCollectionApiResponse(IEnumerable<Book> books, int? currentPage, int? pageCount, int? totalCount) {
            Entity = books.Select(book => new BookApiResponse(book));
            CurrentPage = currentPage ?? 0;
            PageCount = pageCount ?? 0;
            TotalCount = totalCount ?? 0;
        }
    }
}
