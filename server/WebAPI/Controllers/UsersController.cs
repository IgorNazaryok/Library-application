using Entities.DataAccess;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
   // [Authorize]
    [Route("[controller]")]

    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult<IEnumerable<UserDTO>> Get()
        {

            IEnumerable<UserDTO> objectList = _userService.GetUsers();
            return Ok(objectList);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<User> Post(UserDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userService.CreateUser(user);
            return Ok();
        }
    }
}
