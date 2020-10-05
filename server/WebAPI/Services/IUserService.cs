﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        void CreateUser(UserDTO userDTO);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
