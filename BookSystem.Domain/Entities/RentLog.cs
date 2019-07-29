using System;

namespace BookSystem.Domain.Entities
{
    public partial class RentLog
    {
        public int RentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime RentStartTime { get; set; }
        public DateTime RentEndTime { get; set; }

        public virtual Books Book { get; set; }
        public virtual Users User { get; set; }
    }
}
