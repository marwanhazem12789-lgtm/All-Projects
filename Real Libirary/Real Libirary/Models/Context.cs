using Microsoft.EntityFrameworkCore;

namespace Real_Libirary.Models
{
    public class Context : DbContext
    { 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\marwanhazem;Initial Catalog=""Real Libirary"";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate= True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);


            modelBuilder.Entity<Order>().HasOne(o => o.Book).WithMany(b => b.Orders).HasForeignKey(o => o.BookId);
        }

    }
}
