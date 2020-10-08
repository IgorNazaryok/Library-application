using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.Models
{    public class BookReader
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
