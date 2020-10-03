using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.Models
{    public class BookAuthors
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
