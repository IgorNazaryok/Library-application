
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
        public void AddBookReader(BookReader bookReader)
        {           
            bookReadersRepository.Create(bookReader);
        }
        public void DeleteBookReader(int bookId, int userId) 
        {
            bookReadersRepository.Delete(bookId, userId);
        }
    }
}
