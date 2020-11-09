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
        private readonly IBookReadersRepository bookReadersRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IBookReadersRepository bookReadersRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.bookReadersRepository = bookReadersRepository;
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
        public List<BookDTO> GetBooksByReaderId(int ReaderId)
        {
            List<int> booksID = bookReadersRepository.GetBookIDsByReaderId(ReaderId);
            if (booksID.Count() != 0)
            {
                List<Book> books = new List<Book>();
                foreach (int bookId in booksID)
                {
                    books.Add(bookRepository.GetBookById(bookId));
                }
                return mapper.Map<List<BookDTO>>(books);
            }   
            return null;
        }
        public int CreateBook(BookDTO bookDTO)
        {
            Book book = mapper.Map<BookDTO, Book>(bookDTO);
            return bookRepository.Create(book);
        }
        public void Update(BookDTO bookDTO)
        {
            Book book = mapper.Map<BookDTO, Book>(bookDTO);
            bookRepository.Update(book);
        }
        public void Delete(int id)        
        {            
            bookRepository.Delete(id);
        }
    }
}
