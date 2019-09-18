using Entities.Entities;
using System.Collections.Generic;

namespace Services.Interfaces.Features.Search {
    public interface IBookSearchService {
        IEnumerable<Book> Search(string keyword, int[] categoryIds, int skip, int take);

        IEnumerable<Category> ListCategories();

        Book FindById(int id);

        int CountAllBooks();
    }
}