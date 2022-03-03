using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Library.Core.Entities
{
    public partial class Editorials
    {
        public Editorials()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Campus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
