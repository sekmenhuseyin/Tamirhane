using System.Data.Entity;
using Tamirhane.Core.Models;

namespace Tamirhane.Infrastructure
{
    public class TamirhaneInitalizeDB : DropCreateDatabaseIfModelChanges<TamirhaneDbContext>
    {
        protected override void Seed(TamirhaneDbContext context)
        {
            context.User.Add(new User { FirstName = "Hüseyin", LastName = "Sekmenoğlu", Email = "mail@gmail.com", Tel = "+905004003322" });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}