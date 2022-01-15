using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.DL.Interfaces
{
   public interface IReaderRepository
    {
        Reader Create(Reader reader);

        Reader Update(Reader reader);

        Reader Delete(int id);

        Reader GetById(int id);

        IEnumerable<Reader> GetAll();
    }
}
