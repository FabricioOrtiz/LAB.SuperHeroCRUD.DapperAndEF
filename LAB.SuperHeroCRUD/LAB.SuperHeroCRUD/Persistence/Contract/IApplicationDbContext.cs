using LAB.SuperHeroCRUD.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;

namespace LAB.SuperHeroCRUD.Persistence.Contract
{
    public interface IApplicationDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        public DbSet<SuperHero> SuperHero { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
