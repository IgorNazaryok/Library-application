using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public interface IUserRepository : IRepository<UserDTO>
    {
        IEnumerable<User> GetAllUsers();
        void Create(User user);
    }
}
