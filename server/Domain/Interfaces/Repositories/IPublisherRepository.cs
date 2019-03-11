using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> ListAll();
    }
}