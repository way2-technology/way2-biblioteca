using System;
using Newtonsoft.Json;

namespace Domain.Entities {
    public class Book {
        public int Id { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("AuthorName")]
        public Author[] Authors { get; set; }
        [JsonProperty("ISBN")]
        public string ISBN10 { get; set; }
        [JsonProperty("ISBN13")]
        public string ISBN13 { get; set; }
        [JsonProperty("GoodreadsId")]
        public string GoodreadsId { get; set; }
        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("SmallImageUrl")]
        public string SmallImageUrl { get; set; }
        [JsonProperty("PublicationDate")]
        public DateTime PublicationDate { get; set; }
        [JsonProperty("Publisher")]
        public Publisher Publisher { get; set; }
        [JsonProperty("Language")]
        public Language Language { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("AverageRating")]
        public decimal? AverageRating { get; set; }
        [JsonProperty("RatingCount")]
        public int? RatingCount { get; set; }
        [JsonProperty("NumberOfPages")]
        public int? NumberOfPages { get; set; }
        [JsonProperty("GoodreadsUrl")]
        public string GoodreadsUrl { get; set; }
        public BookLoan[] Loans => new BookLoan[0];
        public int Quantity => 1;
        public Category[] Categories { get; set; }
    }
}