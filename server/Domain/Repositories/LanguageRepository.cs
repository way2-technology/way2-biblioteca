using Domain.Entities;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ISqlConnectionHelper _helper;

        public LanguageRepository(ISqlConnectionHelper helper)
        {
            _helper = helper;
        }

        public IEnumerable<Language> ListAll()
        {
            return _helper.Query<Language>("select id as ID, language_name as Name, language_shortname as Shortname from LANGUAGE;");
        }
    }
}