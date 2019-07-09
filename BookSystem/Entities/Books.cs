using System;
using System.Collections.Generic;

namespace BookSystem.Entities
{
    public partial class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int? UserRentId { get; set; }
        public int UserFunderId { get; set; }

        public virtual Users UserFunder { get; set; }
        public virtual Users UserRent { get; set; }
    }
}
