using System.Data.Entity;
using Tamirhane.Core.Models;

namespace Tamirhane.Infrastructure
{
    public class TamirhaneDbContext : DbContext
    {
        public TamirhaneDbContext()
           : base("name=TamirhaneConnection")
        {
        }
        public virtual DbSet<User> User { get; set; }
    }
}