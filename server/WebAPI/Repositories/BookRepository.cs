using Entities.DataAccess;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public class BookRepository : Repository<BookDTO>, IBookRepository
    {
        public BookRepository(LibraryDbContext context)
            : base(context)
        { }

        public List<Book> GetAllBooks()
        {
            return _dbContext.Books
                .Include(n => n.BookAuthor)
                    .ThenInclude(n => n.Author)
                    .ToList();
        }
        public Book GetBookById(int id)
        {
            return _dbContext.Books
                .Include(n => n.BookAuthor)
                    .ThenInclude(n => n.Author)
                    .Where(x => x.Id == id)
                    .First();
        }
        public int Create(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            Book newBook = _dbContext.Books.FirstOrDefault(x => x.Name == book.Name);
            return newBook.Id;
        }
        public void Update(Book book)
        {
            _dbContext.Update(book);
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Book book = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }
    }
}
