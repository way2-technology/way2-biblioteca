using Domain.Entities;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Domain.Repositories
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