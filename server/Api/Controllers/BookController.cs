using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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
        // TODO: método para popular arquivo de dados do MiniBiggy com os dados do JOSN original. Pode ser apagado assim que a base de dados estiver toda verificada.
        public IActionResult PopulateMiniBiggy() {
            var books = _bookRepository.ListAll(0, int.MaxValue);
            _bookRepository.Save(books);
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}