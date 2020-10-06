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
        void AddBookReader(BookReader bookReader);      
        void DeleteBookReader(int bookId, int userId);
    }
}
