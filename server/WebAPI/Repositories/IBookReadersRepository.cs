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
        BookReader Create(BookReader bookReaders);
        List<int> GetBookIDsByReaderId(int ReaderId);
        BookReader Delete(int bookId, int userId);
    }
}
