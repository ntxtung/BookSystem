using System;
using System.Collections.Generic;

namespace BookSystem.Entities
{
    public partial class UsersReviewsBooks
    {
        public int UsersId { get; set; }
        public int BooksId { get; set; }
        public int ReviewScore { get; set; }
        public string ReviewDetails { get; set; }

        public virtual Books Books { get; set; }
        public virtual Users Users { get; set; }
    }
}
