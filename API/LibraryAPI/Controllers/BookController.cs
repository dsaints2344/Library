using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.Repository;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books =  await _bookService.GetAllBooks();
            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                var book = await _bookService.GetBook(id);
                return Ok(book);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookModel bookToCreate)
        {
            try
            {
                var newBook = await _bookService.AddBook(bookToCreate);
                return Ok(newBook);
            }
            catch (DbUpdateException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
