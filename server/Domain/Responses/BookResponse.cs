using System;
using Domain.Entities;

namespace Domain.Responses {
    public class BookResponse {
        public string Title { get; }
        public string[] Authors { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public DateTime PublicationDate { get; }
        public BookLoan[] BookLoans => new[] {
            new BookLoan()
        };
        public int Quantity => 1;

        public BookResponse(Book book) {
            Title = book.Title;
            Authors = book.Authors.Split(",");
            Description = book.Description;
            ImageUrl = book.ImageUrl;
            PublicationDate = book.PublicationDate;
        }

    }
}
