
using AutoMapper;
using Travel_Library.Core.DTOs;
using Travel_Library.Core.Entities;

namespace Travel_Library.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Authors, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Editorials, EditorialDto>();
            CreateMap<Author_has_Books, Author_has_BooksDto>();
            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
