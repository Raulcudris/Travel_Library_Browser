using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Library.Core.Entities
{
    public partial class Author_has_Books
    {
        public int AuthorsId { get; set; }
        public int BookIsbn { get; set; }

        public virtual Authors Authors { get; set; }
        public virtual Book BookIsbnNavigation { get; set; }
    }
}
