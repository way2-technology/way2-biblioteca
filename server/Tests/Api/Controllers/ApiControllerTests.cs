using System;
using System.Collections.Generic;
using System.Linq;
using Api.Controllers;
using Domain.Entities;
using Domain.Interfaces.Services.Search;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Api.Controllers {
    public class ApiControllerTests {
        private readonly Mock<IBookSearchService> _bookSearchServiceMock;
        private readonly ApiController _controller;

        public ApiControllerTests() {
            _bookSearchServiceMock = new Mock<IBookSearchService>();
            _controller = new ApiController(_bookSearchServiceMock.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Books_ShouldReturnMessageIfNoKeywordIsGiven(string data) {
            var expected = new JsonResult("no keyword given");
            var actual = _controller.Books(data);
            Assert.Equal(expected.Value.ToString(), actual.Value.ToString());
        }

        [Fact]
        public void Books_ShouldReturnData() {
            var data = new[]{
                new Book {
                    //Authors = "author",
                    Description = "description",
                    ImageUrl = "imageUrl",
                    //ISBN = "isbn",
                    PublicationDate = new DateTime(2018, 6, 3),
                    SmallImageUrl = "smallImageUrl"
                }
            };
            _bookSearchServiceMock.Setup(mock => mock.Search(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(data);
            var expected = JsonConvert.SerializeObject(data.Select(item => new BookResponse(item)));
            var actual = JsonConvert.SerializeObject((IEnumerable<BookResponse>) _controller.Books("some words here").Value);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Books_ShouldReturnDataWhenSearchResponseItIsEmpty() {
            _bookSearchServiceMock.Setup(mock => mock.Search(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new Book[0]);
            var expected = JsonConvert.SerializeObject(new BookResponse[0]);
            var actual = JsonConvert.SerializeObject((IEnumerable<BookResponse>) _controller.Books("some words here").Value);
            Assert.Equal(expected, actual);
        }
    }
}
