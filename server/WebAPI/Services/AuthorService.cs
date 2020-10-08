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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }
        public List<int> CreateAuthor(List<AuthorDTO> authorsDTO)
        {
            List<int> authorsId = new List<int>();
            foreach (var item in authorsDTO) 
            {
                Author author = mapper.Map<AuthorDTO, Author>(item);
                if (authorRepository.Create(author)!=null) 
                {
                    authorsId.Add(authorRepository.Create(author).Id);
                }
            }
            return authorsId;
        }
        public void Delete(List<int> AuthorsID)        
        {
            foreach (int id in AuthorsID)
            {
                authorRepository.Delete(id);
            }
        }
    }
}
