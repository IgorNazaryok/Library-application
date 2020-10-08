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
    public class AuthorRepository : Repository<AuthorDTO>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context)
            : base(context)
        { }

        public Author Create(Author author)
        {
            Author value = _dbContext.Authors.FirstOrDefault(x => x.FullName == author.FullName);
            if(value==null)
            {
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
                Author newAuthor = _dbContext.Authors.FirstOrDefault(x => x.FullName == author.FullName);
                return newAuthor;
            }
            return value;
        }
        public void Delete(int id)
        {
            Author author = _dbContext.Authors.FirstOrDefault(x => x.Id == id);

            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
            }
        }
    }
}
