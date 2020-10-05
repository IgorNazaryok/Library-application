using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public interface IBookRepository : IRepository<BookDTO>
    {
        List<Book> GetAllBooks();
        public Book GetBookById(int id);
        int Create(Book book);
        void Update(Book book);
        void Delete(int id);

    }
}
