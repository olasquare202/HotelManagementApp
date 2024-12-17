using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.BookingFolder
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> writeAnyThing) : base(writeAnyThing) 
        {
            
        }
        public DbSet<Booking> Bookings { get; set; } 
    }
}
