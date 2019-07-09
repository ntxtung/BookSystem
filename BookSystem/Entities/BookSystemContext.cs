using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=206.189.40.187;port=3307;user=root;password=xuantung98;database=BookSystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("Books", "BookSystem");

                entity.HasIndex(e => e.UsersFundId)
                    .HasName("fk_Books_Users_FundId");

                entity.HasIndex(e => e.UsersRentId)
                    .HasName("fk_Books_Users_RentId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(45)
                    .IsUnicode(false);

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
                entity.HasKey(e => new { e.RentId, e.UserId, e.BookId });

                entity.ToTable("Rent_Log", "BookSystem");

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

                entity.Property(e => e.RentEndTime).HasColumnName("rent_endTime");

                entity.Property(e => e.RentStartTime)
                    .HasColumnName("rent_startTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
                entity.HasKey(e => new { e.UserId, e.BookId });

                entity.ToTable("User_Request_Book", "BookSystem");

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
                entity.ToTable("Users", "BookSystem");

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
