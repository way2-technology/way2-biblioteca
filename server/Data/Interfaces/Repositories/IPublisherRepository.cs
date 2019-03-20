using Entities.Entities;
using System.Collections.Generic;

namespace Data.Interfaces.Repositories
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> ListAll();
    }
}