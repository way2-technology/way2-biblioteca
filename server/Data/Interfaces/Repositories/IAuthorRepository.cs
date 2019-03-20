using Entities.Entities;
using System.Collections.Generic;

namespace Data.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> ListAll();
    }
}