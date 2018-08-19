using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Settings;
using MiniBiggy;
using Newtonsoft.Json;

namespace Domain.Repositories {
    public class BookRepository : IBookRepository {
        private readonly IAppSettingsServices _appSettings;
        private PersistentList<Book> _books;

        public BookRepository(IAppSettingsServices appSettings) {
            _appSettings = appSettings;
            _books = Create.ListOf<Book>()
                .SavingAt("Static\\bookDatabase.data")
                .UsingPrettyJsonSerializer()
                .SavingWhenRequested();
        }

        public IEnumerable<Book> ListAll(int skip, int take) {
            var content = GetContentFromFile();
            return ParseJson(content).Skip(skip).Take(take);
        }

        private IEnumerable<Book> ParseJson(string jsonContent) =>
            (IEnumerable<Book>) JsonConvert.DeserializeObject(jsonContent, typeof(List<Book>));

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
        private string GetContentFromFile() => System.IO.File.ReadAllText(_appSettings.JsonBookFilePath, Encoding.UTF8);
        public void Save(Book bookToSave) {
            var bookFound = _books.Where(b => b.Id == bookToSave.Id).SingleOrDefault();
            if (bookFound != null) {
                MapPropertiesToUpdate(bookToSave, bookFound);
            }
            else {
                _books.Add(bookToSave);
            }
            _books.Save();
        }

        private void MapPropertiesToUpdate(Book origin, Book destination) {
            destination.Title = origin.Title;
            destination.Authors = origin.Authors;
            destination.SmallImageUrl = origin.SmallImageUrl;
            destination.ImageUrl = origin.ImageUrl;
            destination.ISBN = origin.ISBN;
            destination.Description = origin.Description;
            destination.PublicationDate = origin.PublicationDate;
        }

        // TODO: método para popular a base json do MiniBiggy, vai ser deprecado assim que todos os dados dos livros forem verificados
        public void Save(IEnumerable<Book> books) {
            var id = 0;
            foreach (var book in books) {
                book.Id = ++id;
                _books.Add(book);
            }
            _books.Save();
        }

        public Book Load(int id) {
            return _books.SingleOrDefault(book => book.Id == id);
        }
    }
}
