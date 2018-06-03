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

        public IEnumerable<Book> ListAll(int skip, int take) {
            var content = GetContentFromFile();
            return ParseJson(content).Skip(skip).Take(take);
        }

        private IEnumerable<Book> ParseJson(string jsonContent) =>
            (IEnumerable<Book>) JsonConvert.DeserializeObject(jsonContent, typeof(List<Book>));

        private string GetContentFromFile() => System.IO.File.ReadAllText(_filePath, Encoding.UTF8);

        public IEnumerable<Book> Search(string keyword, int skip, int take) {
            var content = GetContentFromFile();
            return ParseJson(content)
                .Where(book =>
                    book.Title.ToUpper().Contains(keyword.ToUpper()) ||
                    (book.Description != null && book.Description.ToUpper().Contains(keyword.ToUpper())) ||
                    (book.Authors != null && book.Authors.ToUpper().Contains(keyword.ToUpper()))
                    )
                .Skip(skip).Take(take).ToList();
        }
    }
}
