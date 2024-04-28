using System;

public class LoanModel
{
    public required string BorrowerName { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public BookModel? Book { get; set; }
}
