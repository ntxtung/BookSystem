using System.ComponentModel.DataAnnotations;

namespace BookSystem.Entities {
    public class BasicUsersDTO {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Avatar { get; set; }
    }
}