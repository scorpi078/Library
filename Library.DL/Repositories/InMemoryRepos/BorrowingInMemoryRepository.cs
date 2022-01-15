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
   public class BorrowingInMemoryRepository : IBorrowingRepository
    {
        public BorrowingInMemoryRepository()
        {

        }
        public Borrowing Create(Borrowing borrowing)
        {
            BorrowingInMemoryCollection.BorrowingsDb.Add(borrowing);

            return borrowing;
        }

        public Borrowing Delete(int id)
        {
            var borrowing = BorrowingInMemoryCollection.BorrowingsDb.FirstOrDefault(borrowing => borrowing.Id == id);

            BorrowingInMemoryCollection.BorrowingsDb.Remove(borrowing);

            return borrowing;
        }

        public IEnumerable<Borrowing> GetAll()
        {
            return BorrowingInMemoryCollection.BorrowingsDb;
        }

        public Borrowing GetById(int id)
        {
            return BorrowingInMemoryCollection.BorrowingsDb.FirstOrDefault(bor => bor.Id == id);
        }

        public Borrowing Update(Borrowing borrowing)
        {
            var result = BorrowingInMemoryCollection.BorrowingsDb.FirstOrDefault(bor => bor.Id == borrowing.Id);

            result.Id = borrowing.Id;
            result.Books = borrowing.Books;
            result.Readers = borrowing.Readers;
            result.Librarians = borrowing.Librarians;
            result.BorrowedDate = borrowing.BorrowedDate;
            result.ReturnDate = borrowing.ReturnDate;

            return result;
        }
    }
}
