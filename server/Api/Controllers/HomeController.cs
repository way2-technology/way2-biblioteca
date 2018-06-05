using Domain.Interfaces.Services.Search;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    public class HomeController : Controller {
        private readonly IBookSearchService _bookSearchService;

        public HomeController(IBookSearchService bookSearchService) {
            _bookSearchService = bookSearchService;
        }

        public IActionResult Index() {
            var bookList = _bookSearchService.ListAll(0, int.MaxValue);
            return View(bookList);
        }
    }
}