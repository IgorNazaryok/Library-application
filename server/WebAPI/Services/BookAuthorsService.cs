
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
                BookAuthors bookAuthors = new BookAuthors();
                bookAuthors.BookId = bookId;
                bookAuthors.AuthorId = authorId;
                bookAuthorsRepository.Create(bookAuthors);
            }
        }

        public IEnumerable<int> DeleteBookAuthors(int BookId) 
        {
            return bookAuthorsRepository.Delete(BookId);
        }
    }
}
