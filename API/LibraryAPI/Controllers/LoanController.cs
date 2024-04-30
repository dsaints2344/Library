using Application.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private IBookLoanService _bookLoanService;

        public LoanController(IBookLoanService bookLoanService)
        {
            _bookLoanService = bookLoanService;
        }
       
        // POST api/<LoanController>
        [HttpPost]
        public async Task<IActionResult> UpsertLoan([FromBody] LoanModel loanModel)
        {
            var loanToUpsert = await _bookLoanService.UpsertLoan(loanModel);

            if (loanToUpsert > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("return-loan")]
        [HttpPost]
        public async Task<IActionResult> ReturnLoan([FromBody] LoanModel loanModel)
        {
            var loanUpdate = await _bookLoanService.ReturnLoan(loanModel);

            if (loanUpdate > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
