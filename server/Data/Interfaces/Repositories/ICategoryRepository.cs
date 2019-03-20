using Entities.Entities;
using System.Collections.Generic;

namespace Data.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> ListAll();
    }
}