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
   public class LibrarianInMemoryRepository : ILibrarianRepository
    {
        public LibrarianInMemoryRepository()
        {

        }

        public Librarian Create(Librarian librarian)
        {
            LibrarianInMemoryCollection.LibrariansDb.Add(librarian);

            return librarian;
        }

        public Librarian Delete(int id)
        {
            var librarian = LibrarianInMemoryCollection.LibrariansDb.FirstOrDefault(librarian => librarian.Id == id);

            LibrarianInMemoryCollection.LibrariansDb.Remove(librarian);

            return librarian;
        }

        public IEnumerable<Librarian> GetAll()
        {
            return LibrarianInMemoryCollection.LibrariansDb;
        }

        public Librarian GetById(int id)
        {
            return LibrarianInMemoryCollection.LibrariansDb.FirstOrDefault(l => l.Id == id);
        }

        public Librarian Update(Librarian librarian)
        {
            var result = LibrarianInMemoryCollection.LibrariansDb.FirstOrDefault(l => l.Id == librarian.Id);

            result.Id = librarian.Id;
            result.Name = librarian.Name;

            return result;
        }
    }
}
