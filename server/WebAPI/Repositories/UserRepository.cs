using Entities.DataAccess;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

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
