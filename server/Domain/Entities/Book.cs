using System;
using Newtonsoft.Json;

namespace Domain.Entities {
    public class Book {
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("AuthorName")]
        public string Authors { get; set; }
        [JsonProperty("SmallImageUrl")]
        public string SmallImageUrl { get; set; }
        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("ISBN")]
        public string ISBN { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("PublicationDate")]
        public DateTime PublicationDate { get; set; }
        public BookLoan[] Loans => new BookLoan[0];
        public int Quantity => 1;
    }
}