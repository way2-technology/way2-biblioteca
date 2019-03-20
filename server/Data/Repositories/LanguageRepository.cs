using Entities.Entities;
using Data.Interfaces.Helpers;
using Data.Interfaces.Repositories;
using System.Collections.Generic;

namespace Data.Repositories
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