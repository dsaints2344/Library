export class Loan {
    loanDate: Date = new Date();
    returnDate: Date | null = null;
    borrowerId: number | null = null;
    bookId: number | null = null;
    amountToBorrowOrReturn: number = 0;
}