using Domain.Entities;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Domain.Repositories
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