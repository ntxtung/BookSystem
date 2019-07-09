using System;
using System.Collections.Generic;

namespace BookSystem.Entities
{
    public partial class User
    {
        public User()
        {
            BookUserFunder = new HashSet<Book>();
            BookUserRent = new HashSet<Book>();
            RentLog = new HashSet<RentLog>();
            UserRequestsBook = new HashSet<UserRequestsBook>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Book> BookUserFunder { get; set; }
        public virtual ICollection<Book> BookUserRent { get; set; }
        public virtual ICollection<RentLog> RentLog { get; set; }
        public virtual ICollection<UserRequestsBook> UserRequestsBook { get; set; }
    }
}
