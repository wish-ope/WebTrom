using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WebTruyen.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<Comic> Truyens { get; set; }
        public DbSet<Author> TacGias { get; set; }
        public DbSet<Category> TheLoais { get; set; }
        public DbSet<User> NguoiDungs { get; set; }
        public DbSet<TRUYEN_TG> Truyen_TGs { get; set; }
        public DbSet<TRUYEN_TL> Truyen_TLs { get; set; }
        public DbSet<TRUYEN_USER> THEO_DOIs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ nhiều-nhiều
            modelBuilder.Entity<TRUYEN_TG>()
                .HasKey(t => new { t.IDTruyen, t.IDTacGia });

            modelBuilder.Entity<TRUYEN_TL>()
                .HasKey(t => new { t.IDTruyen, t.IDTheLoai });

            modelBuilder.Entity<TRUYEN_USER>()
                .HasKey(t => new { t.IDUser, t.IDTruyen });

        }
    }
}
