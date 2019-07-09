using System;
using System.Collections.Generic;

namespace BookSystem.Entities
{
    public partial class UserRequestBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual Users User { get; set; }
    }
}
