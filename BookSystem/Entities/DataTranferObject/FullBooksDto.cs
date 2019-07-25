using System.ComponentModel.DataAnnotations;

namespace BookSystem.Entities {
    public class FullBooksDto {
        public FullBooksDto() {
        }

        public FullBooksDto(Books book) {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Image = book.Image;
        }

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