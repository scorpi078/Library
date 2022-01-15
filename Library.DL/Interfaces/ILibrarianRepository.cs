using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.DL.Interfaces
{
   public interface ILibrarianRepository
    {
        Librarian Create(Librarian librarian);

        Librarian Update(Librarian librarian);

        Librarian Delete(int id);

        Librarian GetById(int id);

        IEnumerable<Librarian> GetAll();

    }
}
