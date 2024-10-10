using System.ComponentModel.DataAnnotations;

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
