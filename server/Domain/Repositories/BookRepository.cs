using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Settings;
using Newtonsoft.Json;

namespace Domain.Repositories {
    public class BookRepository : IBookRepository {
        private readonly IAppSettingsServices _appSettings;

        public BookRepository(IAppSettingsServices appSettings) {
            _appSettings = appSettings;
        }

        public IEnumerable<Book> ListAll() {
            var content = GetContentFromFile();
            return ParseJson(content);
        }

        private IEnumerable<Book> ParseJson(string jsonContent) =>
            (IEnumerable<Book>)JsonConvert.DeserializeObject(jsonContent, typeof(List<Book>));

        private string GetContentFromFile() => System.IO.File.ReadAllText(_appSettings.JsonBookFilePath, Encoding.UTF8);
    }
}
