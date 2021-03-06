﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public interface IBookAuthorsService
    {
        void AddBookAuthors(int bookId, List<int> authorsId);
        IEnumerable<int> DeleteBookAuthors(int idBook);
    }
}
