using System.Collections.Generic;
using Domain.Entities;
using Domain.Responses;

namespace Api.Models.Home {

    public class HomeViewModel {
        public IEnumerable<BookResponse> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}