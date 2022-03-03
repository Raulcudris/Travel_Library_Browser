using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.Entities;

namespace Travel_Library.Core.Interfaces
{
   public  interface IEditorialRepository
    {
        Task<IEnumerable<Editorials>> GetEditorials();
        Task<Editorials> GetEditorials(int id);
        Task Inserteditorial(Editorials editorial);

    }
}
