using LAB.SuperHeroCRUD.Persistence.Contract;
using System.Data;

namespace LAB.SuperHeroCRUD.Persistence
{
    public class ApplicationWriteDbConnection : IApplicationWriteDbConnection
    {
        public Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
