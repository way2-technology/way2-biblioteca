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
        public void Search_ShouldUseRepositirytoSearch()
        {
            var skip = 2;
            var take = 42;
            var categoryIds = new[] { 1, 2, 3 };
            var keyword = "something to search for";
            _bookSearchService.Search(keyword, categoryIds, skip, take);
            _bookRepositoryMock.Verify(mock => mock.Search(keyword, categoryIds, skip, take));
        }
    }
}