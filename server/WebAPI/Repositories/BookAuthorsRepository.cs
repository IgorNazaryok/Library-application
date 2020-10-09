using Entities.DataAccess;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public class BookAuthorsRepository : Repository<BookAuthors>, IBookAuthorsRepository
    {
        public BookAuthorsRepository(LibraryDbContext context)
            : base(context)
        { }
        public void Create(BookAuthors bookAuthor)
        {            
              _dbContext.BookAuthors.Add(bookAuthor);
              _dbContext.SaveChanges();
        }
        public IEnumerable<BookAuthors> GetBookAuthorsByBookId(int BookId)
        {
              return _dbContext.BookAuthors.Where(x => x.BookId == BookId).Select(u=>u);
        }

        public BookAuthors GetBookAutorByAuthorId(int AuthorId)
        {
            return _dbContext.BookAuthors.FirstOrDefault(x => x.AuthorId == AuthorId);
              //  Where(x => x.AuthorId == AuthorId).First();
        }

        public void Delete(BookAuthors bookAuthor)
        {
              _dbContext.BookAuthors.Remove(bookAuthor);
              _dbContext.SaveChanges();
        }
    }
}
