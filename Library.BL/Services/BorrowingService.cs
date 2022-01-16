using Library.BL.Interfaces;
using Library.DL.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using UniLibrary.Models.DTO;

namespace Library.BL.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly ILogger _logger;

        public BorrowingService(IBorrowingRepository borrowingRepository, ILogger logger)
        {
            _borrowingRepository = borrowingRepository;
            _logger = logger;
        }

        public Borrowing Create(Borrowing borrowing)
        {
            try
            {
              var index = _borrowingRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

              borrowing.Id = (int)(index != null ? index + 1 : 1);
              return _borrowingRepository.Create(borrowing);

            } catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            _logger.Information("Borrowing Create()");

            return _borrowingRepository.Create(borrowing);
        }

        public Borrowing Delete(int id)
        {
            _logger.Information("Borrowing Delete() ");

            return _borrowingRepository.Delete(id);
        }

        public IEnumerable<Borrowing> GetAll()
        {
            _logger.Information("Borrowing GetAll() ");

            return _borrowingRepository.GetAll();
        }

        public Borrowing GetById(int id)
        {
            _logger.Information("Borrowing GetById() ");

            return _borrowingRepository.GetById(id);
        }

        public Borrowing Update(Borrowing borrowing)
        {
            _logger.Information("Borrowing Update() ");

            return _borrowingRepository.Update(borrowing);
        }
    }
}
