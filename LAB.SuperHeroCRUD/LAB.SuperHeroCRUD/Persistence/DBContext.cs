using LAB.SuperHeroCRUD.Model;
using LAB.SuperHeroCRUD.Persistence.Contract;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LAB.SuperHeroCRUD.Persistence
{
    public class DBContext : DbContext, IApplicationDbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> SuperHero { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();
    }
}
