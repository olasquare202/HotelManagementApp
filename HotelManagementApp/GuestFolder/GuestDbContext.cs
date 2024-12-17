using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.Data
{
    public class GuestDbContext : DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Guest> Guests { get; set; }
    }
}
