using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
      //  public List<BookAuthors> BookAuthor { get; set; }
    }
}
