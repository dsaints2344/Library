namespace Domain
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
        public required string ISBN { get; set; }
        public required int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }

        public required Category Category { get; set; } // Enforces required category
    }
}
