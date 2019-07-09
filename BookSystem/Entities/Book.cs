using System;
using System.Collections.Generic;

namespace BookSystem.Entities
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoricalId { get; set; }
        public string Image { get; set; }
        public int? UserRentId { get; set; }
        public int UserFunderId { get; set; }

        public virtual User UserFunder { get; set; }
        public virtual User UserRent { get; set; }
    }
}
