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
        private readonly IBookService booksService;
        private readonly IAuthorService authorService;
        private readonly IBookAuthorsService booksAuthorService;

        public BooksController(IBookService booksService, IAuthorService authorService, IBookAuthorsService booksAuthorService)
        {
            this.booksService = booksService;
            this.authorService = authorService;
            this.booksAuthorService = booksAuthorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            List<BookDTO> objectList = booksService.GetBooks();
            return Ok(objectList);
        }        
        [HttpGet("{id}")]
        public ActionResult GetBooksById(int id)
        {
            BookDTO objectList = booksService.GetBookById(id);
            return Ok(objectList);
        }
        [HttpPost]
        public ActionResult<Book> Post(BookDTO bookDTO)
        {
            int bookId = booksService.CreateBook(bookDTO);
            List <int> authorsId = authorService.CreateAuthor(bookDTO.Authors);
            booksAuthorService.AddBookAuthors(bookId, authorsId);
            return Ok();
        }
        [HttpPut]
        public ActionResult<Book> Put(BookDTO bookDTO)
        {
            booksService.Update(bookDTO);
            return Ok();
        }
        [HttpDelete("{BookId}")]
        public ActionResult<Book> Delete(int BookId)
        {
            List<int> AuthorsID=booksAuthorService.DeleteBookAuthors(BookId).ToList();
            booksService.Delete(BookId);
            authorService.Delete(AuthorsID);
            return Ok();
        }
    }
}
