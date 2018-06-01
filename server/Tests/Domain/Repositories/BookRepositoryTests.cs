using System;
using System.Linq;
using Domain.Repositories;
using Domain.Responses;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Domain.Repositories {
    public class BookRepositoryTests {
        private readonly BookRepository _repo;

        public BookRepositoryTests() {
            _repo = new BookRepository("./Domain/Repositories/livros.json");
        }

        [Fact]
        public void ListAll_ShouldListAllRecordsInFile() {
            var books = _repo.ListAll();
            var expected = new[] { "A Cultura Toyota: A Alma do Modelo Toyota", "A Meta - Um Processo de Melhoria Contínua" };
            var titles = books.Select(book => book.Title).ToArray();
            Assert.All(titles, item => expected.Contains(item));
        }

        [Fact]
        public void ListAll_ShouldMappPropertiesCorrectly() {
            var expected = new Book {
                Title = "Livro A",
                PublicationDate = new DateTime(2003, 1, 1),
                Authors = "Uncle Bob",
                Description = "Descricao do livro A",
                ISBN = "8521312369",
                ImageUrl = "https://images.gr-assets.com/books/1364317608m/17695175m.jpg",
                SmallImageUrl = "https://images.gr-assets.com/books/1364317608s/17695175s.jpg",
            };
            var actual = JsonConvert.SerializeObject(_repo.ListAll().First());
            Assert.Equal(JsonConvert.SerializeObject(expected), actual);
        }
    }
}
