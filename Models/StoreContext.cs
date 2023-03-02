using Microsoft.EntityFrameworkCore;

namespace Kirtland_Artist_Guild.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Art> Arts { get; set; }
    }
}
