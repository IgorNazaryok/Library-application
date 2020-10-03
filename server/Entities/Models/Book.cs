using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }        
        public ICollection<BookAuthors> BookAuthor { get; set; }
    }
}
