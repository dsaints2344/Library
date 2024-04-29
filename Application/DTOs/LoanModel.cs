using System;

public class LoanModel
{
    public required string BorrowerName { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int BookId { get; set; }
    public int AmountToBorrow { get; set; }
}
