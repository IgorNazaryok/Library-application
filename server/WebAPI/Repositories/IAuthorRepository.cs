using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public interface IAuthorRepository : IRepository<AuthorDTO>
    {
        int Create(Author author);
        void Delete(int BookId);
    }
}
