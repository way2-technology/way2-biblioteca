using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces {
    public interface IBookRepository {
        IEnumerable<Book> ListAll(int skip, int take);
        IEnumerable<Book> Search(string keyword, int skip, int take);
        void Save(Book book);
        void Save(IEnumerable<Book> book);
        Book Load(int id);
    }
}
