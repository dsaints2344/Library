using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IBookLoanService
    {
        Task<int> UpsertLoan(LoanModel loanModel);
        Task<int> ReturnLoan(LoanModel loanModel);
    }
}
