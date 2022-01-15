using Library.BL.Interfaces;
using Library.DL.Interfaces;

using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger _logger;

        public BookService(IBookRepository bookRepository, ILogger logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public Book Create(Book book)
        {
            _logger.Information("Book Create() Error");

            var index = _bookRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            book.Id = (int)(index != null ? index + 1 : 1);

            return _bookRepository.Create(book);
        }

        public Book Delete(int id)
        {
            _logger.Information("Book Delete() Error");

            return _bookRepository.Delete(id);
        }

        public IEnumerable<Book> GetAll()
        {
            _logger.Information("Book GetAll() Error");

            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            _logger.Information("Book GetById() Error");

            return _bookRepository.GetById(id);
        }

        public Book Update(Book book)
        {
            _logger.Information("Book Update() Error");

            return _bookRepository.Update(book);
        }
    }
}
