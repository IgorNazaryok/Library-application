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
        [HttpGet]
        //public ActionResult GetAllBookReaders()
        //{
        //    List<BookDTO> objectList = booksReadersService.GetBookReaders();
        //    return Ok(objectList);
        //}        
        //[HttpGet("{id}")]
        //public ActionResult GetBookReadersById(int id)
        //{
        //    BookDTO objectList = booksReadersService.GetBookById(id);
        //    return Ok(objectList);
        //}
        [HttpPost]
        public ActionResult<BookReader> Post(BookReader booksReader)
        {
            booksReadersService.AddBookReader(booksReader);
            return Ok();
        }

        [HttpDelete("{bookId}/{userId}")]
        public ActionResult<BookReader> Delete(int bookId, int userId)
        {
            booksReadersService.DeleteBookReader(bookId, userId);
            return Ok();
        }
    }
}
