namespace Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public required int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BorrowerId { get; set; }
        public int AmountBorrowed { get; set; }


        // navigation properties
        public required Book Book { get; set; }
        public int? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
