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
        public BookReader Create(BookReader newBookReader)
        {
            BookReader bookReader = _dbContext.BookReaders.FirstOrDefault(x => x.BookId == newBookReader.BookId && x.UserId == newBookReader.UserId);
            if (bookReader == null)
            {
                _dbContext.BookReaders.Add(newBookReader);
                _dbContext.SaveChanges();
            }
            return bookReader;
        }        
        public BookReader Delete(int bookId, int userId)
        {
            BookReader bookReader = _dbContext.BookReaders.FirstOrDefault(x => x.BookId == bookId && x.UserId == userId);
            if (bookReader != null)
            {
                _dbContext.BookReaders.Remove(bookReader);
                _dbContext.SaveChanges();
            }
            return bookReader;
        }

        public List<int> GetBookIDsByReaderId(int ReaderId)
        {
            return _dbContext.BookReaders.Where(x => x.UserId == ReaderId).Select(x=>x.BookId).ToList();
        }
    }
}
