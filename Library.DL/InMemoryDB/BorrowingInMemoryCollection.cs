using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;
using UniLibrary.Models.Enums;

namespace Library.DL.InMemoryDB
{
    public static class BorrowingInMemoryCollection
    {
        public static List<Borrowing> BorrowingsDb = new List<Borrowing>()
        {
           new Borrowing()
           {
               Id = 1,
               Books = new List<Book>()
               {
                   new Book()
                   {
                       Id = 1,
                       AuthorName = "Author1",
                       Category = Category.Chemistry,
                       Name = "Book1"
                   },
               },
               Readers = new List<Reader>()
               {
                   new Reader()
                   {
                        Id = 1,
                        Name = "Reader1",
                        PhoneNumber = 0871234567
                   }
               },
               Librarians = new List<Librarian>()
               {
                   new Librarian()
                   {
                       Id = 1,
                       Name = "Librarian1"
                   }
               },
               
               BorrowedDate = new DateTime(2021, 05, 21),
               ReturnDate = new DateTime(2021, 06, 21)
           },
           new Borrowing()
           {
               Id = 2,
               Books = new List<Book>()
               {
                   new Book()
                   {
                       Id = 2,
                       AuthorName = "Author2",
                       Category = Category.ComputerScience,
                       Name = "Book2"
                   },
               },
               Readers = new List<Reader>()
               {
                   new Reader()
                   {
                        Id = 2,
                        Name = "Reader2",
                        PhoneNumber = 0871234937
                   }
               },
               Librarians = new List<Librarian>()
               {
                   new Librarian()
                   {
                       Id = 2,
                       Name = "Librarian2"
                       
                   }
               },
             
               BorrowedDate = new DateTime(2021, 03, 06),
               ReturnDate = new DateTime(2021, 04, 06)
           },
           new Borrowing()
           {
               Id = 3,
               Books = new List<Book>()
               {
                   new Book()
                   {
                       Id = 3,
                       AuthorName = "Author3",
                       Category = Category.Math,
                       Name = "Book3"
                   },
               },
               Readers = new List<Reader>()
               {
                   new Reader()
                   {
                        Id = 3,
                        Name = "Reader3",
                        PhoneNumber = 0874534567
                   }
               },
               Librarians = new List<Librarian>()
               {
                   new Librarian()
                   {
                       Id = 3,
                       Name = "Librarian3"
                       
                   }
               },
       
               BorrowedDate = new DateTime(2021, 10, 15),
               ReturnDate = new DateTime(2021, 11, 15)
           }
        };

    }
}
