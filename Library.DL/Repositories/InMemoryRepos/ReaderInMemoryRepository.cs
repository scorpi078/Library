using Library.DL.InMemoryDB;
using Library.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.DL.Repositories
{
   public class ReaderInMemoryRepository : IReaderRepository
    {
        public ReaderInMemoryRepository()
        {

        }
        public Reader Create(Reader reader)
        {
            ReaderInMemoryCollection.ReadersDb.Add(reader);

            return reader;
        }

        public Reader Delete(int id)
        {
            var reader = ReaderInMemoryCollection.ReadersDb.FirstOrDefault(reader => reader.Id == id);

            ReaderInMemoryCollection.ReadersDb.Remove(reader);

            return reader;
        }

        public IEnumerable<Reader> GetAll()
        {
            return ReaderInMemoryCollection.ReadersDb;
        }

        public Reader GetById(int id)
        {
            return ReaderInMemoryCollection.ReadersDb.FirstOrDefault(r => r.Id == id);
        }

        public Reader Update(Reader reader)
        {
            var result = ReaderInMemoryCollection.ReadersDb.FirstOrDefault(r => r.Id == reader.Id);

            result.Id = reader.Id;
            result.Name = reader.Name;
            result.PhoneNumber = reader.PhoneNumber;

            return result;
        }
    }
}
