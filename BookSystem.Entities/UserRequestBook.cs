namespace BookSystem.Entities
{
    public partial class UserRequestBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual Books Book { get; set; }
        public virtual Users User { get; set; }
    }
}
