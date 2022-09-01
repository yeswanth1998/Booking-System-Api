using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<UserInfo> users { get; set; }

    }
}
