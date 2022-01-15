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
    public class ReaderController : ControllerBase
    {
        private readonly IReaderService _readerService;
        private readonly IMapper _mapper;

        public ReaderController(IReaderService readerService, IMapper mapper)
        {
            _readerService = readerService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _readerService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _readerService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<ReaderResponse>(result);

            return Ok(response);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] ReaderRequest readerRequest)
        {
            if (readerRequest == null) return BadRequest();

            var reader = _mapper.Map<Reader>(readerRequest);

            var result = _readerService.Create(reader);

            return Ok(result);
        }
        

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _readerService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Reader reader)
        {
            if (reader == null) return BadRequest();

            var searchOrderItem = _readerService.GetById(reader.Id);

            if (searchOrderItem == null) return NotFound(reader.Id);

            searchOrderItem.Name = reader.Name;
            searchOrderItem.PhoneNumber = reader.PhoneNumber;

            var result = _readerService.Update(searchOrderItem);

            return Ok(result);
        }
    }
}
