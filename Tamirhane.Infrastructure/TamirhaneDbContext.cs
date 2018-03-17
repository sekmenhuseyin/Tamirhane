using System.Data.Entity;

namespace Tamirhane.Infrastructure
{
    public class TamirhaneDbContext : DbContext
    {
        public TamirhaneDbContext()
           : base("name=ProductAppConnectionString")
        {
        }
        public DbSet User { get; set; }
    }
}