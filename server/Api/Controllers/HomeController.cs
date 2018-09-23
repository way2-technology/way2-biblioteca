using System;
using System.Linq;
using Domain.Interfaces.Services.Search;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    public class HomeController : Controller {
        private readonly IBookSearchService _bookSearchService;

        public HomeController(IBookSearchService bookSearchService) {
            _bookSearchService = bookSearchService;
        }

        public IActionResult Index() {
            var bookList = _bookSearchService.ListAll(0, int.MaxValue);
            var viewModelList = bookList.Select(book => new BookResponse(book));
            return View(viewModelList);
        }

        public IActionResult Search(string q) {
            var bookList = String.IsNullOrWhiteSpace(q) ? 
                _bookSearchService.ListAll(0, int.MaxValue) : 
                _bookSearchService.Search(q, 0, int.MaxValue);
            var viewModelList = bookList.Select(book => new BookResponse(book));
            return View("Index", viewModelList);
        }
    }
}