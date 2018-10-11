using System;
using Domain.Entities;

namespace Domain.Responses {

    public class BookResponse {
        public int Id { get; set; }
        public string Title { get; }
        public string[] Authors { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public DateTime PublicationDate { get; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Rating { get; set; }
        public int RatingCount { get; set; }
        public string ISBN { get; set; }
        public Category[] Categories { get; set; }

        public BookLoan[] BookLoans => new[] {
            new BookLoan()
        };

        public int Quantity => 1;

        public BookResponse(Book book) {
            Id = book.Id;
            Title = book.Title;
            Authors = book.Authors?.Split(",");
            Description = book.Description;
            ImageUrl = book.ImageUrl;
            PublicationDate = book.PublicationDate;
            NumberOfPages = book.NumberOfPages ?? 0;
            Publisher = book.Publisher;
            Language = book.Language;
            Rating = GetRatingScaleFive(book.AverageRating);
            RatingCount = book.RatingCount ?? 0;
            ISBN = book.ISBN ?? book.ISBN13 ?? string.Empty;
            Categories = book?.Categories;
        }

        private string GetRatingScaleFive(decimal? averageRating) => !averageRating.HasValue ? "0" : (averageRating.Value * 100 / 5).ToString().Replace(",", ".");
    }
}