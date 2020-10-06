using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public interface IBookAuthorsRepository : IRepository<BookAuthors>
    {
        void Create(BookAuthors bookAuthors);
        IEnumerable<BookAuthors> GetBookAuthorsByBookId(int BookId);
        void Delete(BookAuthors bookAuthor);
    }
}
