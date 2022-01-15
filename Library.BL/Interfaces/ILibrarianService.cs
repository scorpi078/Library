using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.BL.Interfaces
{
   public interface ILibrarianService
    {
        Librarian Create(Librarian librarian);

        Librarian Update(Librarian librarian);

        Librarian Delete(int id);

        Librarian GetById(int id);

        IEnumerable<Librarian> GetAll();
    }
}
