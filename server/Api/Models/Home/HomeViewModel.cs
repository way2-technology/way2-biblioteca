using System.Collections.Generic;
using Entities.Entities;
using Entities.Responses;

namespace Api.Models.Home {

    public class HomeViewModel {
        public IEnumerable<BookResponse> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}