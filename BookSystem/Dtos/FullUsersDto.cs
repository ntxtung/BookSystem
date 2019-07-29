using System.ComponentModel.DataAnnotations;
using BookSystem.Entities;

namespace BookSystem.Dtos {
    public class FullUsersDto {
        public FullUsersDto() {
            
        }
        public FullUsersDto(Users user) {
            Id = user.Id;
            Username = user.Username;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Token = user.Token;
            Avatar = user.Avatar;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string Avatar { get; set; }
        public int Role { get; set; }
    }
}