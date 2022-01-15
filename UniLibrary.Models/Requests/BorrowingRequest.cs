using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;
using UniLibrary.Models.Enums;

namespace Library.Models.Requests
{
  public  class BorrowingRequest
    {
        public List<Book> Books { get; set; }

        public List<Reader> Readers { get; set; }

        public List<Librarian> Librarians { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
