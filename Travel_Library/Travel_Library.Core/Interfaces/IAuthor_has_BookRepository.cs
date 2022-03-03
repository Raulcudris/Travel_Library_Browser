using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.Entities;

namespace Travel_Library.Core.Interfaces
{
   public  interface IAuthor_has_BookRepository
    {
        Task<IEnumerable<Author_has_Books>> GetAuthor_has_Books();
        Task<Author_has_Books> GetAuthor_has_Books(int id);
        Task InsertAuthor_has_Book(Author_has_Books author_has_book);

    }
}
