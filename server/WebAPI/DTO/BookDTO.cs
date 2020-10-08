using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "The value must be greater than zero")]
        public int Amount { get; set; }
        [Required]
        public List<AuthorDTO> Authors { get; set; }
        public List<ReaderDTO> Readers { get; set; }
    }
}
