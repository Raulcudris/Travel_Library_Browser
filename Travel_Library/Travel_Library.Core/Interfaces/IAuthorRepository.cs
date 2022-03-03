using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.Entities;

namespace Travel_Library.Core.Interfaces
{
   public  interface IAuthorRepository
    {
        Task<IEnumerable<Authors>>GetAuthors();
        Task<Authors> GetAuthors(int id);
        Task InsertAuthor (Authors author);

    }
}
