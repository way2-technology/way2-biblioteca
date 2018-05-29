using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    public class HomeController : Controller
    {
        private readonly IRepositorioDeLivros _repositorioDeLivros;
        public HomeController(IRepositorioDeLivros repositorioDelivros) {
            _repositorioDeLivros = repositorioDelivros;
        }

        public IActionResult Index()
        {
            var lista = _repositorioDeLivros.ListeTodos();
            return View(lista);
        }
    }
}