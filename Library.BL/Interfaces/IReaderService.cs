using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.BL.Interfaces
{
   public interface IReaderService
    {
        Reader Create(Reader reader);

        Reader Update(Reader reader);

        Reader Delete(int id);

        Reader GetById(int id);

        IEnumerable<Reader> GetAll();
    }
}
