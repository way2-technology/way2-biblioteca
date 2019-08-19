using Entities.Requests;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Features.Search;
using System.Linq;

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

        [HttpGet]
        public JsonResult Book(int id) {
            var book = _bookSearchService.FindById(id);
            if (book == null) {
                return new JsonResult(null);
            }
            return new JsonResult(new BookResponse(book));
        }

        [HttpGet]
        public JsonResult GetBooks(int? limit, int? page) {
            var skip = GetSkip(page, limit);
            var take = limit ?? int.MaxValue;
            var books = _bookSearchService.ListAll(skip, take);
            var response = new BookCollectionApiResponse(books, page.Value, limit.Value);
            return new JsonResult(response);
        }

        [HttpGet]
        public JsonResult SearchBooks(int? limit, int? page, string search) {
            var skip = GetSkip(page, limit);
            var take = limit ?? int.MaxValue;
            var books = _bookSearchService.Search(search, skip, take);
            var response = new BookCollectionApiResponse(books, page.Value, limit.Value);
            return new JsonResult(response);
        }

        private int GetSkip(int? page, int? limit) =>
            (page * limit) ?? 0;

        [HttpPost]
        public JsonResult RateBook(RateBookRequest request) {
            // TODO: implementrar controle de usuário é requsito
            var book = _bookSearchService.FindById(3);
            return new JsonResult(new BookApiResponse(book));
        }

        [HttpPost]
        public JsonResult BorrowBook(BorrowBookRequest request) {
            // TODO: implementrar controle de usuário é requsito
            var book = _bookSearchService.FindById(2);
            return new JsonResult(new BookApiResponse(book) {
                Borrowed = new BorrowedApiResponse {
                    Email = "some@email.com",
                    AvatarUrl = "/somedir/me.jpg"
                }
            });
        }
    }
}