using AutoMapper;
using Library.BL.Interfaces;
using Library.Models.Requests;
using Library.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using UniLibrary.Models.DTO;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _bookService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<BookResponse>(result);

            return Ok(response);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] BookRequest bookRequest)
        {
            if (bookRequest == null) return BadRequest();

            var book = _mapper.Map<Book>(bookRequest);

            var result = _bookService.Create(book);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _bookService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            var searchOrderItem = _bookService.GetById(book.Id);

            if (searchOrderItem == null) return NotFound(book.Id);

            searchOrderItem.Name = book.Name;
            searchOrderItem.AuthorName = book.AuthorName;
            searchOrderItem.Category = book.Category;

            var result = _bookService.Update(searchOrderItem);

            return Ok(result);
        }
    }
}
