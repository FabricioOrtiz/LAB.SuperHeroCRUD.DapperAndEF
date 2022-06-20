using LAB.SuperHeroCRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace LAB.SuperHeroCRUD.Persistence
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> SuperHero { get; set; }

    }
}
