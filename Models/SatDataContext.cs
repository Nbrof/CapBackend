using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class SatDataContext : DbContext
    {
        public SatDataContext(DbContextOptions<SatDataContext> options) : base(options)
        {
        }

        public DbSet<SatData> TodoItems { get; set; }
    }
}