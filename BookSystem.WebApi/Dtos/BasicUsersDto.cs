using System.ComponentModel.DataAnnotations;
using BookSystem.Entities;

namespace BookSystem.WebApi.Dtos {
    public class BasicUsersDto {
        public BasicUsersDto() {
            
        }
        public BasicUsersDto(Users user) {
            Id = user.Id;
            Username = user.Username;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
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
        public string Avatar { get; set; }
    }
}