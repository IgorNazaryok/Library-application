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
    //[Authorize]
    [ApiController]
    [Route("[controller]")]

    public class BooksController : Controller
    {
        private readonly IBookService _booksService;

        public BooksController(IBookService booksService)
        {
            this._booksService = booksService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            List<BookDTO> objectList = _booksService.GetBooks();
            return Ok(objectList);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetBooksById(int id)
        {
            BookDTO objectList = _booksService.GetBookById(id);
            return Ok(objectList);
        }


        [HttpPost]
        public ActionResult<Book> Post(BookDTO book)
        {
            _booksService.CreateBook(book);
            return Ok();
        }


        //[HttpPut]
        //public async Task<ActionResult<Book>> Put(Book book)
        //{
        //    if (book == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!db.Books.Any(x => x.Id == book.Id))
        //    {
        //        return NotFound();
        //    }

        //    db.Update(book);
        //    await db.SaveChangesAsync();
        //    return Ok(book);
        //}

 
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Book>> Delete(int id)
        //{
        //    Book book = db.Books.FirstOrDefault(x => x.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    db.Books.Remove(book);
        //    await db.SaveChangesAsync();
        //    return Ok(book);
        //}
    }
}
