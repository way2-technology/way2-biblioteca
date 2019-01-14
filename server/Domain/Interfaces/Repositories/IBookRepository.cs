using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> ListAll(int skip, int take);

        IEnumerable<Book> ListAll(int categoryId, int skip, int take);

        IEnumerable<Book> Search(string keyword, int skip, int take);

        IEnumerable<Category> GetActiveCategories();

        void Save(Book book);

        Book Load(int id);
    }
}