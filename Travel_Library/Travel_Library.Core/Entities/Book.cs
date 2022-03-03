using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Library.Core.Entities
{
    public partial class Book
    {
        public int Isbn { get; set; }
        public int EditorId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string NPages { get; set; }

        public virtual Editorials Editorials { get; set; }
    }
}
