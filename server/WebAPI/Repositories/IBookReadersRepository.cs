using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public interface IBookReadersRepository : IRepository<BookReader>
    {
        void Create(BookReader bookReaders);
        void Delete(int bookId, int userId);
    }
}
