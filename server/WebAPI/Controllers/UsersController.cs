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
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
   // [Authorize]
    [Route("[controller]")]

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult<IEnumerable<UserDTO>> Get()
        {

            IEnumerable<UserDTO> objectList = userService.GetUsers();
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

            userService.CreateUser(user);
            return Ok();
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Token([FromBody]AuthenticateRequest model)
        {
            var response = userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
