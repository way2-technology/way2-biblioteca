using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Responses;
using Newtonsoft.Json;

namespace Domain.Repositories {
    public class BookRepository : IBookRepository {
        private readonly string _filePath;

        public BookRepository(string filePath) {
            _filePath = filePath;
        }

        public IEnumerable<Book> ListAll() {
            var content = GetContentFromFile();
            return ParseJson(content);
        }

        private IEnumerable<Book> ParseJson(string jsonContent) =>
            (IEnumerable<Book>)JsonConvert.DeserializeObject(jsonContent, typeof(List<Book>));

        private string GetContentFromFile() => System.IO.File.ReadAllText(_filePath, Encoding.UTF8);
    }
}
