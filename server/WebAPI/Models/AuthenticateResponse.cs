using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserDTO user, string token)
        {
            Id = user.Id;
            Role = user.Role;
            Token = token;

        }
    }
}
