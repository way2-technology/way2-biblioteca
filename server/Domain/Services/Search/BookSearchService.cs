using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services.Search;
using System.Collections.Generic;

namespace Domain.Services.Search
{
    public class BookSearchService : IBookSearchService
    {
        private readonly IBookRepository _bookRepository;

        public BookSearchService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book FindById(int id) => _bookRepository.Load(id);

        public IEnumerable<Book> ListAll(int skip, int take) => _bookRepository.ListAll(skip, take);

        public IEnumerable<Book> ListAll(int categoryId, int skip, int take) => _bookRepository.ListAll(categoryId, skip, take);

        public IEnumerable<Category> ListCategories() => _bookRepository.GetActiveCategories();

        public IEnumerable<Book> Search(string keyword, int skip, int take) => _bookRepository.Search(keyword, skip, take);
    }
}