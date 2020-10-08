using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } 
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
