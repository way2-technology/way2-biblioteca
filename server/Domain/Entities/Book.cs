using System;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author[] Authors { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public string GoodreadsId { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public Publisher Publisher { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public decimal? AverageRating { get; set; }
        public int? RatingCount { get; set; }
        public int? NumberOfPages { get; set; }
        public string GoodreadsUrl { get; set; }
        public BookLoan[] Loans => new BookLoan[0];
        public int Quantity => 1;
        public Category[] Categories { get; set; }
    }
}