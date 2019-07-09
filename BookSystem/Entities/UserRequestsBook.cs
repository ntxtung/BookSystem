using System;
using System.Collections.Generic;

namespace BookSystem.Entities
{
    public partial class UserRequestsBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual User User { get; set; }
    }
}
