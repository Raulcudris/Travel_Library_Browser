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
    public class EditorialRepository : IEditorialRepository
    {
        private readonly TRAVELContext _context;
        public EditorialRepository(TRAVELContext context)
        {
            _context = context;
        }
                

        public async Task<IEnumerable<Editorials>> GetEditorials()
        {
            var editorials = await _context.Editorials.ToListAsync();
            await Task.Delay(10);
            return editorials;
        }

        public async Task<Editorials> GetEditorials(int id)
        {
            var editorials = await _context.Editorials.FirstOrDefaultAsync(x => x.Id == id);
            return editorials;
        }

        public async Task Inserteditorial(Editorials editorial)
        {
            _context.Editorials.Add(editorial);
            await _context.SaveChangesAsync();
        }

    }
}
