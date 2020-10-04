using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using WebAPI.Repositories;
using AutoMapper;
using WebAPI.DTO;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = userRepository.GetAllUsers();
            return mapper.Map<IEnumerable<UserDTO>>(users.ToList());
        }
        public void CreateUser(UserDTO userDTO)
        {
            User user = mapper.Map<UserDTO, User>(userDTO);
            userRepository.Create(user);
        }
    }
}
