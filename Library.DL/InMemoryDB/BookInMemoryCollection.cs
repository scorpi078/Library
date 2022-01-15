using System.Collections.Generic;
using UniLibrary.Models.DTO;
using UniLibrary.Models.Enums;

namespace Library.DL.InMemoryDB
{
    public static class BookInMemoryCollection
    {
        public static List<Book> BooksDb = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                AuthorName = "Test1",
                Category = Category.Chemistry,
                Name = "Test 1"

            },
            new Book()
            {
                Id = 2,
                AuthorName = "Test2",
                Category = Category.Physics,
                Name = "Test 2"
            },
            new Book()
            {
                Id = 3,
                AuthorName = "Test3",
                Category = Category.Math,
                Name = "Test 3"
            }
        };
    }
}
