using System.Collections.Generic;
using UniLibrary.Models.DTO;

namespace Library.DL.Interfaces
{
   public interface IBorrowingRepository
    {
        Borrowing Create(Borrowing borrowing);

        Borrowing Update(Borrowing borrowing);

        Borrowing Delete(int id);

        Borrowing GetById(int id);

        IEnumerable<Borrowing> GetAll();
    }
}
