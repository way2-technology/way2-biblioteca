using Api.Models.Book;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Api.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository, ICategoryRepository categoryRepository, IPublisherRepository publisherRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            _bookRepository.Save(book);
            return Redirect(Url.Action("Index", "Home"));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new BookEditViewModel
            {
                Book = new BookResponse(_bookRepository.Load(id)),
                AllLanguages = _languageRepository.ListAll().Select(lang => new SelectListItem { Text = lang.Name, Value = lang.Id.ToString() }).ToArray(),
                AllCategories = _categoryRepository.ListAll().Select(cat => new SelectListItem { Text = cat.Name, Value = cat.Id.ToString() }).ToArray(),
                AllPublishers = _publisherRepository.ListAll().Select(pub => new SelectListItem { Text = pub.Name, Value = pub.Id.ToString() }).ToArray(),
                AllAuthors = _authorRepository.ListAll().Select(author => new SelectListItem { Text = author.Name, Value = author.Id.ToString() }).ToArray(),
            };
            return View("Edit", viewModel);
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