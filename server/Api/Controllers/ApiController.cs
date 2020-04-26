using Entities.Requests;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Features.BorrowBook;
using Services.Interfaces.Features.Search;
using System;
using System.Linq;

namespace Api.Controllers
{

    public class ApiController : Controller
    {
        private readonly IBookSearchService _bookSearchService;
        private readonly IBookBorrowService _bookLendService;

        public ApiController(IBookSearchService bookSearchService, IBookBorrowService bookLendService)
        {
            _bookSearchService = bookSearchService;
            _bookLendService = bookLendService;
        }

        [HttpGet]
        public JsonResult GetBook(int id)
        {
            var book = _bookSearchService.FindById(id);
            if (book == null)
            {
                return new JsonResult(null);
            }
            return new JsonResult(new BookResponse(book));
        }

        [HttpGet]
        public JsonResult GetBooks(string keyword, int[] categoryIds, int? limit, int? page)
        {
            var skip = GetSkip(page, limit);
            var take = limit ?? int.MaxValue;
            var books = _bookSearchService.Search(keyword, categoryIds, skip, take);
            var totalCount = _bookSearchService.Search(keyword, categoryIds, 0, int.MaxValue).Count();
            var response = new BookCollectionApiResponse(books, page, totalCount);
            return new JsonResult(response);
        }

        [HttpGet]
        public JsonResult ListAllCategories()
        {
            var response = _bookSearchService.ListCategories().Select(category => new CategoryResponse(category));
            return new JsonResult(response);
        }

        private int GetSkip(int? page, int? limit) =>
            (page * limit) ?? 0;

        [HttpPost]
        public JsonResult RateBook(RateBookRequest request)
        {
            // TODO: implementrar controle de usuário é requsito
            var book = _bookSearchService.FindById(3);
            return new JsonResult(new BookApiResponse(book));
        }

        [HttpPost]
        public JsonResult BorrowBook([FromBody]BorrowBookRequest request)
        {
            try
            {
                if (!ValidateEmailDomain(request.Email))
                {
                    return new JsonResult(new ErrorResponse(400, "Invalid email domain"));
                }
                _bookLendService.BorrowBook(request.BookId, request.Email);
                return new JsonResult("ok");
            }
            catch (Exception ex)
            {
                return new JsonResult(new ErrorResponse(400, $"falha ao finalizar empréstimo de livro: {ex.Message}"));
            }
        }

        private bool ValidateEmailDomain(string email) =>
            email.ToLower().EndsWith("way2.com.br");

        [HttpGet]
        public ViewResult ValidateLoan(string hash)
        {
            _bookLendService.ValidateLoan(hash);
            return View("ConfirmationLoan", "Empréstimo validado com sucesso! Boa leitura :)");
        }
    }
}