using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.PaymentFolder
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> choices) : base(choices) 
        {
            
        }
        public DbSet<Payment> Payments { get; set; }
    }
}
