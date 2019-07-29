using Microsoft.EntityFrameworkCore;

namespace BookSystem.Entities
{
    public partial class BookSystemContext : DbContext
    {
        public BookSystemContext()
        {
        }

        public BookSystemContext(DbContextOptions<BookSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<RentLog> RentLog { get; set; }
        public virtual DbSet<UserRequestBook> UserRequestBook { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersReviewsBooks> UsersReviewsBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=206.189.40.187;port=3307;user=root;password=xuantung98;database=BookSystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasIndex(e => e.UsersFundId)
                    .HasName("fk_Books_Users_FundId");

                entity.HasIndex(e => e.UsersRentId)
                    .HasName("fk_Books_Users_RentId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.UsersFundId)
                    .HasColumnName("Users_fundId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsersRentId)
                    .HasColumnName("Users_rentId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UsersFund)
                    .WithMany(p => p.BooksUsersFund)
                    .HasForeignKey(d => d.UsersFundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Books_Users_Fund");

                entity.HasOne(d => d.UsersRent)
                    .WithMany(p => p.BooksUsersRent)
                    .HasForeignKey(d => d.UsersRentId)
                    .HasConstraintName("fk_Books_Users_Rent");
            });

            modelBuilder.Entity<RentLog>(entity =>
            {
                entity.HasKey(e => new { e.RentId, e.UserId, e.BookId })
                    .HasName("PRIMARY");

                entity.ToTable("Rent_Log");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_RentHistory_Book1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_RentHistory_User1_idx");

                entity.Property(e => e.RentId)
                    .HasColumnName("rent_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RentEndTime)
                    .HasColumnName("rent_endTime")
                    .HasColumnType("timestamp");

                entity.Property(e => e.RentStartTime)
                    .HasColumnName("rent_startTime")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.RentLog)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RentHistory_Book1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RentLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RentHistory_User1");
            });

            modelBuilder.Entity<UserRequestBook>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId })
                    .HasName("PRIMARY");

                entity.ToTable("User_Request_Book");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_User_has_Book_Book1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_User_has_Book_User1_idx");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.UserRequestBook)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_has_Book_Book1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRequestBook)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_has_Book_User1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasColumnType("varchar(55)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<UsersReviewsBooks>(entity =>
            {
                entity.HasKey(e => new { e.UsersId, e.BooksId })
                    .HasName("PRIMARY");

                entity.ToTable("Users_Reviews_Books");

                entity.HasIndex(e => e.BooksId)
                    .HasName("fk_Users_has_Books_Books1_idx");

                entity.HasIndex(e => e.UsersId)
                    .HasName("fk_Users_has_Books_Users1_idx");

                entity.Property(e => e.UsersId)
                    .HasColumnName("Users_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BooksId)
                    .HasColumnName("Books_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReviewDetails)
                    .HasColumnName("Review_details")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ReviewScore)
                    .HasColumnName("Review_score")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.Books)
                    .WithMany(p => p.UsersReviewsBooks)
                    .HasForeignKey(d => d.BooksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_has_Books_Books1");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UsersReviewsBooks)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_has_Books_Users1");
            });
        }
    }
}
