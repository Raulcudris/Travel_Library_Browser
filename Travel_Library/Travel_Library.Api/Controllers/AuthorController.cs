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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorRepository.GetAuthors();
            //Utilizacion de Mapeo
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);          
            return Ok(authorsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthors(int id)
        {
            var authors = await _authorRepository.GetAuthors(id);
            var authorDto = _mapper.Map<AuthorDto>(authors);
            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Author(AuthorDto authorDto)
        {
            var author = _mapper.Map<Authors>(authorDto);        
            await _authorRepository.InsertAuthor(author);
            return Ok(author);
        }
    }
}
