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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly TRAVELContext _context;
        public AuthorRepository(TRAVELContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Authors>> GetAuthors()
        {
            var Authors = await _context.Authors.ToListAsync();

            await Task.Delay(10);
            return Authors;
        }

        public async Task<Authors> GetAuthors(int id)
        {
            var Author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            return Author;
        }

        public async Task InsertAuthor(Authors author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }


    }

}
