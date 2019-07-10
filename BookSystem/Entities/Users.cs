using System.Collections.Generic;

namespace BookSystem.Entities {
    public class Users {
        public Users() {
            BooksUsersFund = new HashSet<Books>();
            BooksUsersRent = new HashSet<Books>();
            RentLog = new HashSet<RentLog>();
            UserRequestBook = new HashSet<UserRequestBook>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Books> BooksUsersFund { get; set; }
        public virtual ICollection<Books> BooksUsersRent { get; set; }
        public virtual ICollection<RentLog> RentLog { get; set; }
        public virtual ICollection<UserRequestBook> UserRequestBook { get; set; }
    }
}