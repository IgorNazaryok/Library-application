using Entities.DataAccess;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    //[Readersize]
    [ApiController]
    [Route("[controller]")]

    public class BookReadersController : Controller
    {
        private readonly IBookReadersService booksReadersService;

        public BookReadersController(IBookReadersService booksReadersService)
        {
            this.booksReadersService = booksReadersService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<BookReader> Post(BookReader booksReader)
        {
            var response = booksReadersService.AddBookReader(booksReader);
            if (response != null)
                return BadRequest(new { message = "You have already take one copy of the book!" });

            return Ok();
        }

        [HttpDelete("{bookId}/{userId}")]
        public ActionResult<BookReader> Delete(int bookId, int userId)
        {
            var response = booksReadersService.DeleteBookReader(bookId, userId);
            if (response == null)
                return BadRequest(new { message = "You can only return a take book!" });

            return Ok();
        }
    }
}
