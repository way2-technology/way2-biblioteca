using Domain.Entities;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ISqlConnectionHelper _helper;

        public PublisherRepository(ISqlConnectionHelper helper)
        {
            _helper = helper;
        }

        public IEnumerable<Publisher> ListAll() => 
            _helper.Query<Publisher>("select id as Id, name as Name from publisher;");
    }
}