using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Responses {
    public class BookCollectionApiResponse : PagedResult<BookApiResponse> {
        public BookCollectionApiResponse(IEnumerable<Book> books, int currentPge, int total) {
            Entity = books.Select(book => new BookApiResponse(book));
            CurrentPage = currentPge;
            Total = total;
        }
    }
}
