using Entities.Entities;

namespace Entities.Responses {
    public class CategoryResponse {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryResponse(Category category) {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
