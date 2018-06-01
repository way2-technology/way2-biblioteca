using System.Collections.Generic;
using System.Linq;
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
            (IEnumerable<Book>) JsonConvert.DeserializeObject(jsonContent, typeof(List<Book>));

        private string GetContentFromFile() => System.IO.File.ReadAllText(_filePath, Encoding.UTF8);

        public IEnumerable<Book> Search(int skip, int take, string keyword) {
            var content = GetContentFromFile();
            return ParseJson(content)
                .Where(book =>
                    book.Title.ToUpper().Contains(keyword.ToUpper())
                    //book.Description.ToUpper().Contains(keyword.ToUpper())
                    //(book.Authors != null && book.Authors.ToUpper().Contains(keyword.ToUpper()))
                    )
                .Skip(skip).Take(take).ToList();
        }
    }
}
