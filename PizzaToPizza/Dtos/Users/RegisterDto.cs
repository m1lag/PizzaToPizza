using System.ComponentModel.DataAnnotations;

namespace PizzaToPizza.Dtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = "";

        [Required]
        [MinLength(2)]
        public string FullName { get; set; } = "";
    }
}