using System;
using System.Collections.Generic;

namespace BookSystem.Entities {
    public partial class Books {
        public Books() {
            RentLog = new HashSet<RentLog>();
            UserRequestBook = new HashSet<UserRequestBook>();
            UsersReviewsBooks = new HashSet<UsersReviewsBooks>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public int? UsersRentId { get; set; }
        public int UsersFundId { get; set; }

        public virtual Users UsersFund { get; set; }
        public virtual Users UsersRent { get; set; }
        public virtual ICollection<RentLog> RentLog { get; set; }
        public virtual ICollection<UserRequestBook> UserRequestBook { get; set; }
        public virtual ICollection<UsersReviewsBooks> UsersReviewsBooks { get; set; }
    }
}