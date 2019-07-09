using System;
using System.Collections.Generic;

namespace BookSystem.Entities
{
    public partial class RentLog
    {
        public int RentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTimeOffset RentStartTime { get; set; }
        public DateTimeOffset RentEndTime { get; set; }

        public virtual User User { get; set; }
    }
}
