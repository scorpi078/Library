using Library.DL.InMemoryDB;
using Library.DL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UniLibrary.Models.DTO;

namespace Library.DL.Repositories
{
    public class BookInMemoryRepository : IBookRepository
    {
        public BookInMemoryRepository()
        {
            
        }
        public Book Create(Book book)
        {
            BookInMemoryCollection.BooksDb.Add(book);

            return book;
        }

        public Book Delete(int id)
        {
            var book = BookInMemoryCollection.BooksDb.FirstOrDefault(book => book.Id == id);

            BookInMemoryCollection.BooksDb.Remove(book);

            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return BookInMemoryCollection.BooksDb;
        }

        public Book GetById(int id)
        {
            return BookInMemoryCollection.BooksDb.FirstOrDefault(b => b.Id == id);
        }

        public Book Update(Book book)
        {
            var result = BookInMemoryCollection.BooksDb.FirstOrDefault(b => b.Id == book.Id);

            result.Id = book.Id;
            result.Name = book.Name;
            result.AuthorName = book.AuthorName;
            result.Category = book.Category;

            return result;
        }
    }
}
