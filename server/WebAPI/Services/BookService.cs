using AutoMapper;
using Entities.DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }
        public List<BookDTO> GetBooks()
        {
            var books = bookRepository.GetAllBooks();
            return mapper.Map<List<BookDTO>>(books.ToList());
        }

        public BookDTO GetBookById(int id)
        {
            var book = bookRepository.GetBookById(id);
            return mapper.Map<BookDTO>(book);
        }

        public void CreateBook(BookDTO bookDTO)
        {
            Book book = mapper.Map<BookDTO, Book>(bookDTO);
            bookRepository.Create(book);
        }
    }
}
