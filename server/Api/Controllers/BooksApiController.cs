using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    public class BooksApiController {
        private readonly IBookRepository _bookRepo;

        public BooksApiController(IBookRepository bookRepo) {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public JsonResult Books(int skip = 0, int take = int.MaxValue, string keyword = "javascript") {
            var result = _bookRepo.Search(skip, take, keyword);
            return new JsonResult(result);
        }
    }
}
