using Data.Interfaces.Repositories;
using Entities.Entities;
using Services.Interfaces.Features.Search;
using System.Collections.Generic;

namespace Services.Features.Search {
    public class BookSearchService : IBookSearchService {
        private readonly IBookRepository _bookRepository;

        public BookSearchService(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public int CountAllBooks() => _bookRepository.CountAll();

        public IEnumerable<Book> FilterByCategory(int categoryId, int? skip, int? take) => _bookRepository.ListAll(new[] { categoryId }, skip ?? 0, take ?? int.MaxValue);

        public Book FindById(int id) => _bookRepository.Load(id);

        public IEnumerable<Book> ListAll(int skip, int take) => _bookRepository.ListAll(skip, take);

        public IEnumerable<Book> ListAll(int[] categoryIds, int skip, int take) => _bookRepository.ListAll(categoryIds, skip, take);

        public IEnumerable<Category> ListCategories() => _bookRepository.GetActiveCategories();

        public IEnumerable<Book> Search(string keyword, int skip, int take) => _bookRepository.Search(keyword, skip, take);
    }
}