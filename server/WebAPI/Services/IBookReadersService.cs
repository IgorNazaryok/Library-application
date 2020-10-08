using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface IBookReadersService
    {
        BookReader AddBookReader(BookReader bookReader);
        BookReader DeleteBookReader(int bookId, int userId);
    }
}
