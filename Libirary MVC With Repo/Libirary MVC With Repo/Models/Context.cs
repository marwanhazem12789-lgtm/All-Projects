using Microsoft.EntityFrameworkCore;

namespace Libirary_MVC_With_Repo.Models
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\marwanhazem;Initial Catalog=Libibi;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.Book)
                .WithMany(b => b.Borrows)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<Borrow>()
                .HasOne(m => m.Member)
                .WithMany(m => m.Borrows)
                .HasForeignKey(m => m.MemberId);
        }
    }
}
