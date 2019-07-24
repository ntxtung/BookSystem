using System.ComponentModel.DataAnnotations;

namespace BookSystem.Entities {
    public class LoginDto {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}