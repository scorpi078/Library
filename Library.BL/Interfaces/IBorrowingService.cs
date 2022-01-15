using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.BL.Interfaces
{
   public interface IBorrowingService
    {
        Borrowing Create(Borrowing borrowing);

        Borrowing Update(Borrowing borrowing);

        Borrowing Delete(int id);

        Borrowing GetById(int id);

        IEnumerable<Borrowing> GetAll();
    }
}
