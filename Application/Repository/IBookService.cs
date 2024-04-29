using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IBookService
    {
        public Task<List<BookModel>> GetAllBooks();
        public Task<BookModel> GetBook(int id);
        public Task<BookModel> AddBook(BookModel book);
    }
}
