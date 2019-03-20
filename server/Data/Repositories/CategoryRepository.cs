using Entities.Entities;
using Data.Interfaces.Helpers;
using Data.Interfaces.Repositories;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISqlConnectionHelper _helper;

        public CategoryRepository(ISqlConnectionHelper helper)
        {
            _helper = helper;
        }

        public IEnumerable<Category> ListAll() =>
            _helper.Query<Category>("select id as ID, name as Name from category;");
    }
}