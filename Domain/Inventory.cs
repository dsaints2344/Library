namespace Domain
{
    public class Inventory
    {
        public int Id { get; set; }
        public required int BookId { get; set; }
        public Book? Book { get; set; }
        public int AvailableCopies { get; set; } = 0;
    }
}
