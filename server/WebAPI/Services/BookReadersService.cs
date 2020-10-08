
using AutoMapper;
using Entities.DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class BookReadersService : IBookReadersService
    {
        private readonly IBookReadersRepository bookReadersRepository;
        private readonly IMapper mapper;

        public BookReadersService(IBookReadersRepository bookReadersRepository, IMapper mapper)
        {
            this.bookReadersRepository = bookReadersRepository;
            this.mapper = mapper;
        }
        public BookReader AddBookReader(BookReader bookReader)
        {           
            return bookReadersRepository.Create(bookReader);
        }
        public BookReader DeleteBookReader(int bookId, int userId) 
        {
            return bookReadersRepository.Delete(bookId, userId);
        }
    }
}
