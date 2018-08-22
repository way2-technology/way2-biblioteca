using System;
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

        public IActionResult Search(string q) {
            var bookList = String.IsNullOrWhiteSpace(q) ? 
                _bookSearchService.ListAll(0, int.MaxValue) : 
                _bookSearchService.Search(q, 0, int.MaxValue);
            return View("Index", bookList);
        }
    }
}