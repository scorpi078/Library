using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.BL.Interfaces
{
    public interface IBookService
    {
        Book Create(Book book);

        Book Update(Book book);

        Book Delete(int id);

        Book GetById(int id);

        IEnumerable<Book> GetAll();
    }
}
