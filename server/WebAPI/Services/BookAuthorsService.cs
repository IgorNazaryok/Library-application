
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
    public class BookAuthorsService : IBookAuthorsService
    {
        private readonly IBookAuthorsRepository bookAuthorsRepository;
        private readonly IMapper mapper;

        public BookAuthorsService(IBookAuthorsRepository bookAuthorsRepository, IMapper mapper)
        {
            this.bookAuthorsRepository = bookAuthorsRepository;
            this.mapper = mapper;
        }
        public void AddBookAuthors(int bookId, List<int> authorsId)
        {

            foreach (int authorId in authorsId)
            {
                BookAuthors bookAuthor = new BookAuthors();
                bookAuthor.BookId = bookId;
                bookAuthor.AuthorId = authorId;
                bookAuthorsRepository.Create(bookAuthor);
            }
        }

        public IEnumerable<int> DeleteBookAuthors(int BookId) 
        {
            List<BookAuthors> bookAuthors = bookAuthorsRepository.GetBookAuthorsByBookId(BookId).ToList();
            if (bookAuthors != null)
            {
                foreach (BookAuthors bookAuthor in bookAuthors)
                {
                    bookAuthorsRepository.Delete(bookAuthor);
                }
            }
            List<BookAuthors> bookAuthorsToRemove = new List<BookAuthors>();
            foreach (BookAuthors bookAuthor in bookAuthors)
            {
               var bookAuthorToRemove = bookAuthorsRepository.GetBookAutorByAuthorId(bookAuthor.AuthorId);
                if (bookAuthorToRemove == null) 
                {
                    bookAuthorsToRemove.Add(bookAuthorToRemove);              
                }
            }
            return bookAuthorsToRemove.Select(u => u.AuthorId);
        }
    }
}
