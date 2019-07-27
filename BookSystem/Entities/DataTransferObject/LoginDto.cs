using System.ComponentModel.DataAnnotations;

namespace BookSystem.Entities.DataTransferObject {
    public class LoginDto {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}