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

        public User Create(User newUser)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Email == newUser.Email);
            if (user == null)
            {
                newUser.Role = "user";
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();
            }
            return user;
        }       
    }
}
