using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.Entities;
using Travel_Library.Core.Interfaces;
using Travel_Library.Infrastructure.Data;

namespace Travel_Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly TRAVELContext _context;
        public BookRepository(TRAVELContext context)
        {
            _context = context;
        }            

        public async Task<IEnumerable<Book>> GetBooks() 
        {
            var Books = await _context.Books.ToListAsync();          

            await Task.Delay(10);
            return Books;
        }

        public async Task<Book>GetBooks(int id)
        {
            var Book = await _context.Books.FirstOrDefaultAsync(x => x.Isbn == id);
            return Book;
        }

        public async Task InsertBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var ConcurreBook = await GetBooks(book.Isbn);
            ConcurreBook.EditorId = book.EditorId;
            ConcurreBook.Isbn = book.Isbn;
            ConcurreBook.Title = book.Title;
            ConcurreBook.NPages = book.NPages;
            ConcurreBook.Synopsis = book.Synopsis;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var ConcurreBook = await GetBooks(id);
            _context.Books.Remove(ConcurreBook);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
