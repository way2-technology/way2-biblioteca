using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _bookRepository.Load(id);
            var viewModel = new BookResponse(book);
            return View(viewModel);
        }
    }
}