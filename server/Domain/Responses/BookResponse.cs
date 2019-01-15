using Domain.Entities;
using System;

namespace Domain.Responses
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; }
        public string ImageUrl { get; }
        public DateTime PublicationDate { get; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public Category[] Categories { get; set; }
        public Author[] AllAuthors { get; set; }
        public Author[] Authors { get; set; }
        public string GoodreadsId { get; set; }
        public Publisher[] AllPublishers { get; set; }
        public Publisher Publisher { get; set; }
        public Language[] AllLanguages { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public decimal? AverageRating { get; set; }
        public int? RatingCount { get; set; }
        public int? NumberOfPages { get; set; }
        public string GoodreadsUrl { get; set; }

        public int Quantity => 1;

        public BookResponse(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            ImageUrl = book.ImageUrl;
            PublicationDate = book.PublicationDate;
            Categories = book.Categories;
            Authors = book.Authors;
            ISBN10 = book.ISBN10;
            ISBN13 = book.ISBN13;
            GoodreadsId = book.GoodreadsId;
            Publisher = book.Publisher;
            Language = book.Language;
            Description = book.Description;
            AverageRating = GetRatingScaleFive(book.AverageRating);
            RatingCount = book.RatingCount;
            NumberOfPages = book.NumberOfPages;
            GoodreadsUrl = book.GoodreadsUrl;
        }

        private decimal GetRatingScaleFive(decimal? averageRating) => 
            !averageRating.HasValue ? 0 : (averageRating.Value * 100 / 5);
    }
}