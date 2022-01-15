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
   public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly ILogger _logger;

        public ReaderService(IReaderRepository readerRepository, ILogger logger)
        {
            _readerRepository = readerRepository;
            _logger = logger;
        }

        public Reader Create(Reader reader)
        {
            _logger.Information("Reader Create() Error");

            var index = _readerRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            reader.Id = (int)(index != null ? index + 1 : 1);

            return _readerRepository.Create(reader);
        }

        public Reader Delete(int id)
        {
            _logger.Information("Reader Delete() Error");

            return _readerRepository.Delete(id);
        }

        public IEnumerable<Reader> GetAll()
        {
            _logger.Information("Reader GetAll() Error");

            return _readerRepository.GetAll();
        }

        public Reader GetById(int id)
        {
            _logger.Information("Reader GetById() Error");

            return _readerRepository.GetById(id);
        }

        public Reader Update(Reader reader)
        {
            _logger.Information("Reader Update() Error");

            return _readerRepository.Update(reader);
        }
    }
}
