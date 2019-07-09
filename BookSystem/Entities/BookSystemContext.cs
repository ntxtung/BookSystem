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

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<RentLog> RentLog { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRequestsBook> UserRequestsBook { get; set; }

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

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserFunderId });

                entity.ToTable("Book", "BookSystem");

                entity.HasIndex(e => e.UserFunderId)
                    .HasName("fk_Book_User1_idx");

                entity.HasIndex(e => e.UserRentId)
                    .HasName("fk_Book_User_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserFunderId)
                    .HasColumnName("User_Funder_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoricalId)
                    .HasColumnName("categoricalId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserRentId)
                    .HasColumnName("User_Rent_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UserFunder)
                    .WithMany(p => p.BookUserFunder)
                    .HasForeignKey(d => d.UserFunderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Book_User1");

                entity.HasOne(d => d.UserRent)
                    .WithMany(p => p.BookUserRent)
                    .HasForeignKey(d => d.UserRentId)
                    .HasConstraintName("fk_Book_User");
            });

            modelBuilder.Entity<RentLog>(entity =>
            {
                entity.HasKey(e => new { e.RentId, e.UserId, e.BookId });

                entity.ToTable("RentLog", "BookSystem");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_RentHistory_Book1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_RentHistory_User1_idx");

                entity.Property(e => e.RentId)
                    .HasColumnName("rentId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("Book_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RentEndTime).HasColumnName("rentEndTime");

                entity.Property(e => e.RentStartTime)
                    .HasColumnName("rentStartTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RentLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RentHistory_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "BookSystem");

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

            modelBuilder.Entity<UserRequestsBook>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId });

                entity.ToTable("User_Requests_Book", "BookSystem");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_User_has_Book_Book1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_User_has_Book_User1_idx");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("Book_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRequestsBook)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_has_Book_User1");
            });
        }
    }
}
