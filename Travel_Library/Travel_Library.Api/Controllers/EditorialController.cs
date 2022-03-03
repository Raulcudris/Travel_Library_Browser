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
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;
        private readonly IMapper _mapper;
        public EditorialController (IEditorialRepository editorialRepository, IMapper mapper)
        {
            _editorialRepository = editorialRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetEditorials()
        {
            var editorials = await _editorialRepository.GetEditorials();
            //Utilizacion de Mapeo
            var editorialDto = _mapper.Map<IEnumerable<EditorialDto>>(editorials);
            return Ok(editorialDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditorial(int id)
        {
            var editorial = await _editorialRepository.GetEditorials(id);
            var editorialDto = _mapper.Map<EditorialDto>(editorial);
            return Ok(editorialDto);
        }
        [HttpPost]
        public async Task<IActionResult> Editorial(EditorialDto editorialDto)
        {
            var editorial = _mapper.Map<Editorials>(editorialDto);
            await _editorialRepository.Inserteditorial(editorial);         
            return Ok(editorial);
        }
    }
}
