using Entities.Entities;
using System;
using System.Linq;

namespace Entities.Responses {
    public class BookApiResponse {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string[] Categories { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Isbn { get; set; }
        public decimal Rating { get; set; }
        public BorrowedApiResponse Borrowed { get; set; }
        public BookApiResponse(Book book) {
            Id = book.Id;
            Title = book.Title;
            Description = book.Description;
            ImageUrl = book.ImageUrl;
            Categories = book.Categories?.Select(category => category.Name).ToArray() ?? new string[0];
            PublicationDate = book.PublicationDate;
            Publisher = book.Publisher?.Name;
            Pages = book.NumberOfPages ?? 0;
            Isbn = book.ISBN13;
            Rating = book.AverageRating ?? 0;
        }
    }
}
