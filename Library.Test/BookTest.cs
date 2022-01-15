using AutoMapper;
using Library.BL.Interfaces;
using Library.BL.Services;
using Library.Controllers;
using Library.DL.Interfaces;
using Library.Extenxions;
using Library.Models.Requests;
using Library.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UniLibrary.Models.DTO;
using Xunit;

namespace Library.Test
{
    public class BookTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _bookRepository;
        private readonly IBookService _bookService;
        private readonly BookController _bookController;

        private IList<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                AuthorName = "Author 1",
                Category = UniLibrary.Models.Enums.Category.Bulgarian,
                Name = "Name 1",
            },  new Book()
            {
                Id = 2,
                AuthorName = "Author 2",
                Category = UniLibrary.Models.Enums.Category.ComputerScience,
                Name = "Name 2",
            }
        };

        public BookTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _bookRepository = new Mock<IBookRepository>();

            var logger = new Mock<ILogger>();

            _bookService = new BookService(_bookRepository.Object, logger.Object);

            _bookController = new BookController(_bookService, _mapper);
        }

        [Fact]
        public void Book_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IBookService>();

            mockedService.Setup(x => x.GetAll()).Returns(Books);

            //inject
            var controller = new BookController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var book = okObjectResult.Value as IEnumerable<Book>;
            Assert.NotNull(book);
            Assert.Equal(expectedCount, book.Count());
        }
        
        [Fact]
        public void Book_GetById_NameCheck()
        {
            //setup
            var booksId = 2;
            var expectedName = "Name 2";

            _bookRepository.Setup(x => x.GetById(booksId))
                .Returns(Books.FirstOrDefault(b => b.Id == booksId));

            //Act
            var result = _bookController.GetById(booksId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as BookResponse;
            var book = _mapper.Map<Book>(response);

            Assert.NotNull(book);
            Assert.Equal(expectedName, book.Name);
        }

        [Fact]
        public void Book_GetById_NotFound()
        {
            //setup
            var bookId = 3;

            _bookRepository.Setup(x => x.GetById(bookId))
                .Returns(Books.FirstOrDefault(b => b.Id == bookId));

            //Act
            var result = _bookController.GetById(bookId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(bookId, response);
        }
        [Fact]
        public void Book_Update_Name()
        {
            var bookId = 1;
            var expectedName = "Updated Book Name";

            var book = Books.FirstOrDefault(x => x.Id == bookId);
            book.Name = expectedName;

            _bookRepository.Setup(x => x.GetById(bookId))
                .Returns(Books.FirstOrDefault(t => t.Id == bookId));
            _bookRepository.Setup(x => x.Update(book))
                .Returns(book);

            //Act
            var bookUpdateRequest = _mapper.Map<Book>(book);
            var result = _bookController.Update(bookUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Book;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }
        [Fact]
        public void Book_Delete_ExistingBook()
        {
            //Setup
            var bookId = 1;

            var book = Books.FirstOrDefault(x => x.Id == bookId);

            _bookRepository.Setup(x => x.Delete(bookId)).Callback(() => Books.Remove(book)).Returns(book);

            //Act
            var result = _bookController.Delete(bookId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Book;
            Assert.NotNull(val);
            Assert.Equal(1, Books.Count);
            Assert.Null(Books.FirstOrDefault(x => x.Id == bookId));
        }
        [Fact]
        public void Book_Delete_NotExisting_Book()
        {
            //Setup
            var bookId = 3;

            var book = Books.FirstOrDefault(x => x.Id == bookId);

            _bookRepository.Setup(x => x.Delete(bookId)).Callback(() => Books.Remove(book)).Returns(book);

            //Act
            var result = _bookController.Delete(bookId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(bookId, response);
        }
        [Fact]
        public void Book_CreateBook()
        {
            //setup
            var book = new Book()
            {
                Id = 3,
                Name = "3",
                AuthorName = "New Author ",
                Category = UniLibrary.Models.Enums.Category.Economics
            };

            _bookRepository.Setup(x => x.GetAll()).Returns(Books);

            _bookRepository.Setup(x => x.Create(It.IsAny<Book>())).Callback(() =>
            {
                Books.Add(book);
            }).Returns(book);

            //Act
            var result = _bookController.Create(_mapper.Map<BookRequest>(book));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Books.FirstOrDefault(x => x.Id == book.Id));
            Assert.Equal(3, Books.Count);

        }
    }
}
