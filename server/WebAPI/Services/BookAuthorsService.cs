
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
            IEnumerable<BookAuthors> bookAuthors = bookAuthorsRepository.GetBookAuthorsByBookId(BookId);
            if (bookAuthors != null)
            {
                foreach (BookAuthors bookAuthor in bookAuthors)
                {
                    bookAuthorsRepository.Delete(bookAuthor);
                }
            }
           return bookAuthors.Select(u => u.AuthorId);
        }
    }
}
