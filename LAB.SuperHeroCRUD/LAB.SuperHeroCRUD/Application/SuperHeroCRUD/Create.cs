using LAB.SuperHeroCRUD.Persistence.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using System.Data.Common;

namespace LAB.SuperHeroCRUD.Application.SuperHeroCRUD
{
    public class Create
    {
        public class SuperHero : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Place { get; set; }
        }

        public class Mediator : IRequestHandler<SuperHero>
        {
            public IApplicationDbContext _dbContext { get; }
            public IApplicationWriteDbConnection _writeDbConnection { get; }
            public Mediator(IApplicationDbContext dbContext, IApplicationWriteDbConnection writeDbConnection)
            {
                _dbContext = dbContext;
                _writeDbConnection = writeDbConnection;
            }

            public async Task<Unit> Handle(SuperHero request, CancellationToken cancellationToken)
            {
                _dbContext.Connection.Open();
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        //_dbContext.Database.UseTransaction(transaction as DbTransaction);
                        //verify if superhero exist by name
                        bool SuperHeroExists = await _dbContext.SuperHero.AnyAsync(a => a.Name == request.Name);
                        if (SuperHeroExists)
                        {
                            throw new Exception("Super already exists!");
                        }
                        //add superHero with dapper
                        var addSuperHeroQuery = $"INSERT INTO SuperHero(Name, FirstName, LastName, Place) VALUES('{request.Name}', '{request.FirstName}', '{request.LastName}', '{request.Place}');" +
                            $"SELECT CAST(SCOPE_IDENTITY() as int)";
                        var superHeroId = await _writeDbConnection.QuerySingleAsync<int>(addSuperHeroQuery, transaction: ((IInfrastructure<DbTransaction>)_dbContext.Database.CurrentTransaction).Instance);

                        if (superHeroId == 0)
                        {
                            throw new Exception("SuperHero Id");
                        }

                        //Commmit
                        transaction.Commit();

                        return Unit.Value;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        _dbContext.Connection.Close();
                    }
                }
            }
        }
    }
}
