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
    public class BookReadersRepository : Repository<BookReader>, IBookReadersRepository
    {
        public BookReadersRepository(LibraryDbContext context)
            : base(context)
        { }
        public void Create(BookReader bookReader)
        {            
              _dbContext.BookReaders.Add(bookReader);
              _dbContext.SaveChanges();
        }        
        public void Delete(int bookId, int userId)
        {
            BookReader bookReader = _dbContext.BookReaders.FirstOrDefault(x => x.BookId == bookId && x.UserId == userId);
            if (bookReader != null)
            {
                _dbContext.BookReaders.Remove(bookReader);
                _dbContext.SaveChanges();
            }
        }
    }
}
