using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Library.Core.DTOs;
using Travel_Library.Core.Entities;
using Travel_Library.Core.Interfaces;

namespace Travel_Library.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Author_has_BookController : ControllerBase
    {
        private readonly IAuthor_has_BookRepository _author_has_bookRepository;
        private readonly IMapper _mapper;
        public Author_has_BookController(IAuthor_has_BookRepository author_has_bookRepository, IMapper mapper)
        {
            _author_has_bookRepository = author_has_bookRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAuthors_has_Books ()
        {
            var authors_has_books = await _author_has_bookRepository.GetAuthor_has_Books();
            //Utilizacion de Mapeo
            var authors_bookDto = _mapper.Map<IEnumerable<Author_has_BooksDto>>(authors_has_books);
            return Ok(authors_bookDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthors_has_Books(int id)
        {
            var author_has_book = await _author_has_bookRepository.GetAuthor_has_Books(id);
            var author_has_bookDto = _mapper.Map<Author_has_BooksDto>(author_has_book);
            return Ok(author_has_bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Author_has_Book(Author_has_BooksDto authors_has_bookDto)   
        {
            var author_has_book = _mapper.Map<Author_has_Books>(authors_has_bookDto);             
            await _author_has_bookRepository.InsertAuthor_has_Book(author_has_book);
            return Ok(author_has_book);
        }

    }
}
