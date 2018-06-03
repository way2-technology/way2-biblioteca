using System;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Settings;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Domain.Repositories {
    public class BookRepositoryTests {
        private readonly BookRepository _repo;
        private Mock<IAppSettingsServices> _appSettingsMock;

        public BookRepositoryTests() {
            _appSettingsMock = new Mock<IAppSettingsServices>();
            _appSettingsMock.SetupGet(mock => mock.JsonBookFilePath).Returns("./Domain/Repositories/livros.json");

            _repo = new BookRepository(_appSettingsMock.Object);
        }

        [Fact]
        public void ListAll_ShouldListAllRecordsInFile() {
            var books = _repo.ListAll(0, int.MaxValue);
            var expected = new[] { "A Cultura Toyota: A Alma do Modelo Toyota", "A Meta - Um Processo de Melhoria Contínua" };
            var titles = books.Select(book => book.Title).ToArray();
            Assert.All(titles, item => expected.Contains(item));
        }

        [Fact]
        public void ListAll_ShouldMappPropertiesCorrectly() {
            var expected = new Book {
                Title = "Book A",
                PublicationDate = new DateTime(2003, 1, 1),
                Authors = "Uncle Bob",
                Description = "Descricao do livro A",
                ISBN = "8521312369",
                ImageUrl = "https://images.gr-assets.com/books/1364317608m/17695175m.jpg",
                SmallImageUrl = "https://images.gr-assets.com/books/1364317608s/17695175s.jpg",
            };
            var actual = JsonConvert.SerializeObject(_repo.ListAll(0, int.MaxValue).First());
            Assert.Equal(JsonConvert.SerializeObject(expected), actual);
        }

        [Fact]
        public void Search_ShouldFindSearchingForTitle() {
            var expected = new[] { "8521312369", "8577804445" };
            var actual = _repo.Search("book", 0, 10).Select(d => d.ISBN).ToArray();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Search_ShouldFindSearchingForAuthor() {
            var expected = new[] { "8521312369", "8577809999" };
            var actual = _repo.Search("bob", 0, 10).Select(d => d.ISBN);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Search_ShouldFindSearchingForDescription() {
            var expected = new[] { "8577809999" };
            var actual = _repo.Search("foRest", 0, 10).Select(d => d.ISBN).ToArray();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("book", 0, 1, new[] { "8521312369" })]
        [InlineData("book", 0, 2, new[] { "8521312369", "8577804445" })]
        [InlineData("book", 1, 1, new[] { "8577804445" })]
        [InlineData("book", 1, 2, new[] { "8577804445" })]
        public void Search_ShouldPaginateCorrectly(string keyword, int skip, int take, string[] isbnExpected) {
            var actual = _repo.Search(keyword, skip, take).Select(item => item.ISBN).ToArray();
            Assert.Equal(isbnExpected, actual);
        }

    }
}
