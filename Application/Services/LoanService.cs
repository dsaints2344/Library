using Application.Repository;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoanService : IBookLoanService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;


        public LoanService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<int> UpsertLoan(LoanModel loanModel)
        {
            var bookToBorrow = await _dataContext.Books.Where(b => b.Id == loanModel.BookId)
                .Include(b => b.Inventory)
                .Select(b => new Domain.Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    CategoryId = b.CategoryId,
                    ISBN = b.ISBN,
                    Inventory = b.Inventory,
                }).FirstOrDefaultAsync();

            var existingLoan = await _dataContext.Loans
                .Include(l => l.Inventory)
                .Where(l => l.BorrowerId == loanModel.BorrowerId && l.BookId == loanModel.BookId)
                .FirstOrDefaultAsync();

            

            if (bookToBorrow == null)
            {
                throw new Exception($"Book with id: {loanModel.BookId} is not found");
            }

            if (bookToBorrow.Inventory == null)
            {
                throw new Exception($"Book inventory not found");
            }

            if (bookToBorrow.Inventory.AvailableCopies < loanModel.AmountToBorrowOrReturn)
            {
                throw new Exception($"Not enough books available for loan");
            }

            if (existingLoan == null)
            {
                var newLoan = _mapper.Map<Loan>(loanModel);
                newLoan.AmountBorrowed = loanModel.AmountToBorrowOrReturn;
                newLoan.InventoryId = bookToBorrow.Inventory.Id;
                bookToBorrow.Inventory.AvailableCopies = bookToBorrow.Inventory.AvailableCopies - loanModel.AmountToBorrowOrReturn;
               


                await _dataContext.Loans.AddAsync(newLoan);
            }

            else
            {
                existingLoan.Inventory!.AvailableCopies -= loanModel.AmountToBorrowOrReturn;
                existingLoan.AmountBorrowed += loanModel.AmountToBorrowOrReturn;
                existingLoan.LoanDate = loanModel.LoanDate;
                existingLoan.ReturnDate = loanModel.ReturnDate;
            }
            return await _dataContext.SaveChangesAsync(); 

        }

        public async Task<int> ReturnLoan(LoanModel loanModel)
        {
            var existingLoan = await _dataContext.Loans
                .Where(l => l.BorrowerId == loanModel.BorrowerId && l.BookId == loanModel.BookId)
                .Include(l => l.Inventory)
                .FirstOrDefaultAsync();

            if (existingLoan == null)
            {
                throw new Exception($"Loan for book id: {loanModel.BookId} not found");
            }

            existingLoan.Inventory!.AvailableCopies += loanModel.AmountToBorrowOrReturn;
            existingLoan.AmountBorrowed -= loanModel.AmountToBorrowOrReturn;

            if (existingLoan.AmountBorrowed == 0)
            {
                _dataContext.Loans.Remove(existingLoan);
            }

            return await _dataContext.SaveChangesAsync();
        }
    }
}
