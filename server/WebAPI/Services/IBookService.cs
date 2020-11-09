using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface IBookService
    {
        List<BookDTO> GetBooks();
        BookDTO GetBookById(int id);
        List<BookDTO> GetBooksByReaderId(int ReaderId);
        int CreateBook(BookDTO bookDTO);
        void Update(BookDTO bookDTO);
        void Delete(int id);
    }
}
