using AutoMapper;
using Library.Models.Requests;
using Library.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.Extenxions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, BookResponse>().ReverseMap();
            CreateMap<BookRequest, Book>().ReverseMap();
            CreateMap<Borrowing, BorrowingResponse>().ReverseMap();
            CreateMap<BorrowingRequest, Borrowing>().ReverseMap();
            CreateMap<Librarian, LibrarianResponse>().ReverseMap();
            CreateMap<LibrarianRequest, Librarian>().ReverseMap();
            CreateMap<Reader, ReaderResponse>().ReverseMap();
            CreateMap<ReaderRequest, Reader>().ReverseMap();
        }

    }
}
