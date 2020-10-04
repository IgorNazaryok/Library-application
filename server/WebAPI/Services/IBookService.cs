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
        void CreateBook(BookDTO bookDTO);
    }
}
