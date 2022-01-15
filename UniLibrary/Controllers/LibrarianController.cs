using AutoMapper;
using Library.BL.Interfaces;
using Library.Models.Requests;
using Library.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService _librarianService;
        private readonly IMapper _mapper;

        public LibrarianController(ILibrarianService librarianService, IMapper mapper)
        {
            _librarianService = librarianService ;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _librarianService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _librarianService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<LibrarianResponse>(result);

            return Ok(response);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] LibrarianRequest librarianRequest)
        {
            if (librarianRequest == null) return BadRequest();

            var librarian = _mapper.Map<Librarian>(librarianRequest);

            var result = _librarianService.Create(librarian);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _librarianService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Librarian librarian)
        {
            if (librarian == null) return BadRequest();

            var searchOrderItem = _librarianService.GetById(librarian.Id);

            if (searchOrderItem == null) return NotFound(librarian.Id);

            searchOrderItem.Name = librarian.Name;
            
            var result = _librarianService.Update(searchOrderItem);

            return Ok(result);
        }
    }
}

