using System;

public class LoanModel
{   
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int BorrowerId { get; set; }
    public int BookId { get; set; }
    public int AmountToBorrowOrReturn { get; set; }
}
