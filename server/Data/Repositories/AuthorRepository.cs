using Entities.Entities;
using Data.Interfaces.Helpers;
using Data.Interfaces.Repositories;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ISqlConnectionHelper _helper;

        public AuthorRepository(ISqlConnectionHelper helper)
        {
            _helper = helper;
        }

        public IEnumerable<Author> ListAll() => 
            _helper.Query<Author>("select id as Id, name as Name from author;");
    }
}