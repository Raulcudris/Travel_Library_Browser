using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Library.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IEditorialRepository EditorialRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IAuthor_has_BookRepository Author_has_BookRepository { get; }
        ISecurityRepository SecurityRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
