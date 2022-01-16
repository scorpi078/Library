using Library.BL.Interfaces;
using Library.DL.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try {
            var index = _bookRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            book.Id = (int)(index != null ? index + 1 : 1);
            return _bookRepository.Create(book);
            }
            catch (Exception e) {
                _logger.Error(e.Message);
            }

            _logger.Information("Book Create()");
            return _bookRepository.Create(book);
        }

        public Book Delete(int id)
        {
            _logger.Information("Book Delete()");

            return _bookRepository.Delete(id);
        }

        public IEnumerable<Book> GetAll()
        {
            _logger.Information("Book GetAll()");

            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {

            _logger.Information("Book GetById()");

            return _bookRepository.GetById(id);
        }

        public Book Update(Book book)
        {
            _logger.Information("Book Update()");

            return _bookRepository.Update(book);
        }
    }
}
