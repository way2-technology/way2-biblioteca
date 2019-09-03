using Entities.Entities;
using System.Collections.Generic;

namespace Services.Interfaces.Features.Search {
    public interface IBookSearchService {
        IEnumerable<Book> Search(string keyword, int skip, int take);

        IEnumerable<Book> ListAll(int skip, int take);

        IEnumerable<Book> ListAll(int categoryId, int skip, int take);

        IEnumerable<Category> ListCategories();

        Book FindById(int id);
        IEnumerable<Book> FilterByCategory(int categoryId, int? skip, int? take);
        int CountAllBooks();
    }
}