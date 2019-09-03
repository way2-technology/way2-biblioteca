using System;
using System.Linq;
using Api.Models.Home;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Features.Search;

namespace Api.Controllers {
    public class HomeController : Controller
    {
        private readonly IBookSearchService _bookSearchService;

        public HomeController(IBookSearchService bookSearchService)
        {
            _bookSearchService = bookSearchService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bookList = _bookSearchService.ListAll(0, int.MaxValue);
            var viewModel = new HomeViewModel
            {
                Books = bookList.Select(book => new BookResponse(book)),
                Categories = _bookSearchService.ListCategories(),
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ListCategory(int cid)
        {
            var viewModel = new HomeViewModel
            {
                Books = _bookSearchService.ListAll(new[] { cid }, 0, int.MaxValue).Select(book => new BookResponse(book)),
                Categories = _bookSearchService.ListCategories(),
            };
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Search(string q)
        {
            var bookList = String.IsNullOrWhiteSpace(q) ?
                _bookSearchService.ListAll(0, int.MaxValue) :
                _bookSearchService.Search(q, 0, int.MaxValue);
            var viewModel = new HomeViewModel
            {
                Books = bookList.Select(book => new BookResponse(book)),
                Categories = _bookSearchService.ListCategories(),
            };
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookSearchService.FindById(id);
            var viewModel = new BookResponse(book);
            return View(viewModel);
        }
    }
}