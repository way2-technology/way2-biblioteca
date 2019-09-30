using System.Collections.Generic;

namespace Entities.Responses {
    public class PagedResult<T> {
        public IEnumerable<T> Entity { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }

    }
}
