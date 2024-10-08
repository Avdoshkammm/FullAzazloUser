using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAzazloUser.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        public string? Comment { get; set; }
    }
}
