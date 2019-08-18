using System.Collections.Generic;

namespace Entities.Responses {
    public class PagedResult<T> {
        public IEnumerable<T> Entity { get; set; }
        public int Total { get; set; }
        public int CurrentPage { get; set; }

    }
}
