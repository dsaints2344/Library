using Application.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class BookService : IBookService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BookService(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }
        public async Task<BookModel> AddBook(BookModel book)
        {
            var newBook = _mapper.Map<Domain.Book>(book);

            var existingBook = await _dataContext.Books.Where(b => b.Title.ToLower() == book.Title.ToLower())
                .FirstOrDefaultAsync();

            if (existingBook != null)
            {
                throw new DbUpdateException($"Book with title {book.Title} already exists");
            }

            await _dataContext.Books.AddAsync(newBook);

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException(ex.Message);
            }

            return book;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = await _dataContext.Books
                .ProjectTo<BookModel>(_mapper.ConfigurationProvider).ToListAsync();

            return books;
        }

        public async Task<BookModel> GetBook(int id)
        {
            var book = await _dataContext.Books
                .Where(b => b.Id == id)
                .ProjectTo<BookModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                throw new Exception($"Book with id: {id} was not found");
            }

            return book;
        }
    }
}
