using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces {
    public interface IBookRepository
    {
        IEnumerable<Book> ListAll();
    }
}
