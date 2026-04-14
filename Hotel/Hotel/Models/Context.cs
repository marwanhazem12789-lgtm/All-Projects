using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class Context : DbContext
    {
        public Context( DbContextOptions<Context> o)  : base(o) 
        { }
        public DbSet<User> users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ServiceType> serviceTypes { get; set; }
        public DbSet<BookingRecord> bookingRecords { get; set; }
  








    }
}
