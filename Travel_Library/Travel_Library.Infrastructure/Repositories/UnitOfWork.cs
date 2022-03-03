using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.Interfaces;
using Travel_Library.Infrastructure.Data;

namespace Travel_Library.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TRAVELContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IAuthor_has_BookRepository _Has_BookRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(TRAVELContext context)
        {
            _context = context;
        }
        public IBookRepository BookRepository =>_bookRepository ?? new BookRepository(_context);
        public IEditorialRepository EditorialRepository => _editorialRepository ?? new EditorialRepository(_context);
        public IAuthorRepository AuthorRepository => _authorRepository  ?? new AuthorRepository(_context);
        public IAuthor_has_BookRepository Author_has_BookRepository => _Has_BookRepository ?? new Author_has_BookRepository(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
