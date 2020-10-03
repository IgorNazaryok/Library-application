using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public ICollection<BookAuthors> BookAuthor { get; set; }
    }
}
