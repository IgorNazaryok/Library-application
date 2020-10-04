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
    public class UserRepository : Repository<UserDTO>, IUserRepository
    {
        public UserRepository(LibraryDbContext context)
            : base(context)
        { }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users;
        }

        public void Create(User value)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Email == value.Email);
            if (user == null)
            {
                _dbContext.Users.Add(value);
                _dbContext.SaveChanges();
            }
        }
    }
}
