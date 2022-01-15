using AutoMapper;
using Library.BL.Interfaces;
using Library.Models.Requests;
using Library.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowingController : ControllerBase
    {

        private readonly IBorrowingService _borrowingService;
        private readonly IMapper _mapper;

        public BorrowingController(IBorrowingService borrowingService, IMapper mapper)
        {
            _borrowingService = borrowingService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _borrowingService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _borrowingService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<BorrowingResponse>(result);

            return Ok(response);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] BorrowingRequest borrowingRequest)
        {
            if (borrowingRequest == null) return BadRequest();

            var borrowing = _mapper.Map<Borrowing>(borrowingRequest);

            var result = _borrowingService.Create(borrowing);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _borrowingService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Borrowing borrowing)
        {
            if (borrowing == null) return BadRequest();

            var searchOrderItem = _borrowingService.GetById(borrowing.Id);

            if (searchOrderItem == null) return NotFound(borrowing.Id);

            searchOrderItem.Books = borrowing.Books;
            searchOrderItem.Librarians = borrowing.Librarians;
            searchOrderItem.Readers = borrowing.Readers;
            searchOrderItem.BorrowedDate = borrowing.BorrowedDate;
            searchOrderItem.ReturnDate = borrowing.ReturnDate;

            var result = _borrowingService.Update(searchOrderItem);

            return Ok(result);
        }
    }
}

