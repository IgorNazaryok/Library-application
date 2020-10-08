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
        [Range(1, 100, ErrorMessage = "The amount must be greater than zero")]
        public int Amount { get; set; }
        [Required]
        public  ICollection<BookAuthors> BookAuthor { get; set; }        
        public  ICollection<BookReader> BookReader { get; set; }
    }
}
