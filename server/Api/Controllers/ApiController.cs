using System.Linq;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Features.Search;

namespace Api.Controllers {

    public class ApiController : Controller {
        private readonly IBookSearchService _bookSearchService;

        public ApiController(IBookSearchService bookSearchService) {
            _bookSearchService = bookSearchService;
        }

        [HttpGet]
        public JsonResult Books(string keyword, int skip = 0, int take = int.MaxValue) {
            if (string.IsNullOrEmpty(keyword?.Trim())) {
                return new JsonResult("no keyword given");
            }
            var searchResult = _bookSearchService.Search(keyword, skip, take);
            var response = searchResult.Select(book => new BookResponse(book));
            return new JsonResult(response);
        }
    }
}