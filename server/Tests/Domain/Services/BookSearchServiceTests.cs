using Data.Interfaces.Repositories;
using Moq;
using Services.Features.Search;
using Xunit;

namespace Tests.Entities.Services {
    public class BookSearchServiceTests
    {
        private readonly BookSearchService _bookSearchService;
        private readonly Mock<IBookRepository> _bookRepositoryMock;

        public BookSearchServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookSearchService = new BookSearchService(_bookRepositoryMock.Object);
        }

        [Fact]
        public void ListAll_ShouldUseRepositirytoList()
        {
            var skip = 2;
            var take = 42;
            _bookSearchService.ListAll(skip, take);
            _bookRepositoryMock.Verify(mock => mock.ListAll(skip, take));
        }

        [Fact]
        public void Search_ShouldUseRepositirytoSearch()
        {
            var skip = 2;
            var take = 42;
            var keyword = "something to search for";
            _bookSearchService.Search(keyword, skip, take);
            _bookRepositoryMock.Verify(mock => mock.Search(keyword, skip, take));
        }
    }
}