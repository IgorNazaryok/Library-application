using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface IAuthorService
    {
        List<int> CreateAuthor(List<AuthorDTO> authorDTO);
        void Delete(List<int> AuthorsID);
    }
}
