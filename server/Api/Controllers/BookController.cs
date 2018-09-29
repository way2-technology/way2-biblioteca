using Domain.Entities;
using Domain.Interfaces;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {

    public class BookController : Controller {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Book book) {
            _bookRepository.Save(book);
            return Redirect(Url.Action("Index", "Home"));
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var book = _bookRepository.Load(id);
            return View("Edit", book);
        }

        [HttpGet]
        public IActionResult Details(int id) {
            var book = _bookRepository.Load(id);
            var viewModel = new BookResponse(book);
            return View(viewModel);
        }
    }
}