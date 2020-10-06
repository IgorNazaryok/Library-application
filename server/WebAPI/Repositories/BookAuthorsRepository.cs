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
        public void Create(BookAuthors bookAuthors)
        {            
              _dbContext.BookAuthors.Add(bookAuthors);
              _dbContext.SaveChanges();
        }
        public IEnumerable<int> Delete(int BookId)
        {
            var bookAuthors = _dbContext.BookAuthors.Where(x => x.BookId == BookId);
            if (bookAuthors != null)
            {
                foreach (BookAuthors item in bookAuthors)
                {
                    _dbContext.BookAuthors.Remove(item);
                    _dbContext.SaveChanges();
                }
            }
            return bookAuthors.Select(u => u.AuthorId);
        }
    }
}
