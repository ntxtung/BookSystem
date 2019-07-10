using System;

namespace BookSystem.Entities {
    public class RentLog {
        public int RentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTimeOffset RentStartTime { get; set; }
        public DateTimeOffset RentEndTime { get; set; }

        public virtual Books Book { get; set; }
        public virtual Users User { get; set; }
    }
}