using Library.BL.Interfaces;
using Library.DL.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var index = _readerRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

                reader.Id = (int)(index != null ? index + 1 : 1);
                return _readerRepository.Create(reader);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            _logger.Information("Reader Create() ");

            return _readerRepository.Create(reader);
        }

        public Reader Delete(int id)
        {
            _logger.Information("Reader Delete() ");

            return _readerRepository.Delete(id);
        }

        public IEnumerable<Reader> GetAll()
        {
            _logger.Information("Reader GetAll() ");

            return _readerRepository.GetAll();
        }

        public Reader GetById(int id)
        {
            _logger.Information("Reader GetById() ");

            return _readerRepository.GetById(id);
        }

        public Reader Update(Reader reader)
        {
            _logger.Information("Reader Update() ");

            return _readerRepository.Update(reader);
        }
    }
}
