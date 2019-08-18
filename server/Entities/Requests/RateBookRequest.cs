namespace Entities.Requests {
    public class RateBookRequest {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Value { get; set; }
    }
}
