﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Repositories
{
    public interface IBookAuthorsRepository : IRepository<BookAuthors>
    {
        void Create(int bookId, List<int> authorsId);
        IEnumerable<int> Delete(int idBook);
    }
}