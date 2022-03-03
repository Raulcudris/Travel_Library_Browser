using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Library.Core.DTOs
{
    public class BookDto
    {
        public int Isbn { get; set; }
        public int EditorId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string NPages { get; set; }
    }
}
