using Entities.Entities;
using System.Collections.Generic;

namespace Data.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> ListAll();
    }
}