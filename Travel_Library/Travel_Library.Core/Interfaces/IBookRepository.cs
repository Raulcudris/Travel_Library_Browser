using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.Entities;

namespace Travel_Library.Core.Interfaces
{
   public  interface IBookRepository
    {
        Task<IEnumerable<Book>>GetBooks();
        Task<Book> GetBooks(int id);
        Task InsertBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);

    }
}
