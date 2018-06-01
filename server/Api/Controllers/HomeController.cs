using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    public class HomeController : Controller {
        private readonly IBookRepository _repositorioDeLivros;
        public HomeController(IBookRepository repositorioDelivros) {
            _repositorioDeLivros = repositorioDelivros;
        }

        public IActionResult Index() {
            var bookList = _repositorioDeLivros.ListAll();
            return View(bookList);
        }
    }
}