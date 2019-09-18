using Api.Controllers;
using Moq;
using Services.Interfaces.Features.Search;

namespace Tests.Api.Controllers {

    public class ApiControllerTests {
        private readonly Mock<IBookSearchService> _bookSearchServiceMock;
        private readonly ApiController _controller;

        public ApiControllerTests() {
            _bookSearchServiceMock = new Mock<IBookSearchService>();
            _controller = new ApiController(_bookSearchServiceMock.Object);
        }
    }
}