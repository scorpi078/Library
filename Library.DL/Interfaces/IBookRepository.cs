using System.Collections.Generic;
using UniLibrary.Models.DTO;

namespace Library.DL.Interfaces
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book Update(Book book);

        Book Delete(int id);

        Book GetById(int id);

        IEnumerable<Book> GetAll();
    }
}
