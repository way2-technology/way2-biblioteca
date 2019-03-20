using Entities.Entities;
using Data.Interfaces.Helpers;
using Data.Interfaces.Repositories;
using System.Collections.Generic;

namespace Data.Repositories
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