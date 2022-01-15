using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.DL.InMemoryDB
{
   public static class LibrarianInMemoryCollection
    {
        public static List<Librarian> LibrariansDb = new List<Librarian>()
        {
           new Librarian()
           {
               Id = 1,
               Name = "Librarian1"
           },
           new Librarian()
           {
               Id = 2,
               Name = "Librarian2"
           },
           new Librarian()
           {
               Id = 3,
               Name = "Librarian3"
           }
        };

    }
}
