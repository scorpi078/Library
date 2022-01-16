using Library.BL.Interfaces;
using Library.DL.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using UniLibrary.Models.DTO;

namespace Library.BL.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _librarianRepository;
        private readonly ILogger _logger;

        public LibrarianService(ILibrarianRepository librarianRepository, ILogger logger)
        {
            _librarianRepository = librarianRepository;
            _logger = logger;
        }

        public Librarian Create(Librarian librarian)
        {
            try
            {
                var index = _librarianRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

                librarian.Id = (int)(index != null ? index + 1 : 1);
                return _librarianRepository.Create(librarian);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            _logger.Information("Librarian Create() ");
                       
            return _librarianRepository.Create(librarian);
        }

        public Librarian Delete(int id)
        {
            _logger.Information("Librarian Delete() ");

            return _librarianRepository.Delete(id);
        }

        public IEnumerable<Librarian> GetAll()
        {
            _logger.Information("Librarian GetAll() ");

            return _librarianRepository.GetAll();
        }

        public Librarian GetById(int id)
        {
            _logger.Information("Librarian GetById() ");

            return _librarianRepository.GetById(id);
        }

        public Librarian Update(Librarian librarian)
        {
            _logger.Information("Librarian Update() ");

            return _librarianRepository.Update(librarian);
        }
    }
}
