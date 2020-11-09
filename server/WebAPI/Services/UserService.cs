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
using WebAPI.Models;

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
        public UserDTO CreateUser(UserDTO userDTO)
        {
            User user = mapper.Map<UserDTO, User>(userDTO);
            user = userRepository.Create(user);
            return mapper.Map<User, UserDTO>(user);
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            UserDTO user = GetUsers().FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return null;
            }
            var now = DateTime.Now;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new AuthenticateResponse(user, token);
        }
    }
}
