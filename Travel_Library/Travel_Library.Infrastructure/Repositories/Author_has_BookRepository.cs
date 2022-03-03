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
    public class Author_has_BookRepository : IAuthor_has_BookRepository
    {
        private readonly TRAVELContext _context;
        public Author_has_BookRepository(TRAVELContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author_has_Books>> GetAuthor_has_Books()
        {
            var Author_has_Books = await _context.Author_Has_Books.ToListAsync();
            await Task.Delay(10);
            return Author_has_Books;
        }

        public async Task<Author_has_Books> GetAuthor_has_Books(int id)
        {
            var Author_Has_Books = await _context.Author_Has_Books.FirstOrDefaultAsync(x => x.AuthorsId == id);
            return Author_Has_Books;
        }

        public async Task InsertAuthor_has_Book(Author_has_Books author_has_book)
        {
            _context.Author_Has_Books.Add(author_has_book);
            await _context.SaveChangesAsync();
        }
    }
}
