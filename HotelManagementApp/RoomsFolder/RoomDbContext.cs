using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.RoomsFolder
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> actions) : base(actions) 
        {
            
        }
        public DbSet<Room> Rooms { get; set; }
    }
}
