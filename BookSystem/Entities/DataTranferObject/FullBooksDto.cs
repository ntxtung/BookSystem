using System.ComponentModel.DataAnnotations;

namespace BookSystem.Entities {
    public class FullBooksDTO {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Image { get; set; }
    }
}