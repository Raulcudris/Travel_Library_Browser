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
using Travel_Library.Infrastructure.Repositories;

namespace Travel_Library.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            //Utilizacion de Mapeo
            var authorsDto = _mapper.Map<IEnumerable<BookDto>>(books);         
            return Ok(authorsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetBooks(int id)
        {
            var book = await _bookRepository.GetBooks(id);
            var bookDto = _mapper.Map<BookDto>(book);          
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookDto bookDto) 
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.InsertBook(book);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> BookPut(int id, BookDto bookDto) 
        {
            var book = _mapper.Map<Book>(bookDto);
            book.Isbn = id;
            await _bookRepository.UpdateBook(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BookDelete(int id)
        {
           var result =  await _bookRepository.DeleteBook(id);
            return Ok(result);
        }
    }
}
