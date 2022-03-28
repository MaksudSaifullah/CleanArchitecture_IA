
using Internal.Audit.Domain.Common;

namespace Internal.Audit.Application.Contracts.Persistent;

public interface IAsyncQueryRepository<TEntity> where TEntity : EntityBase
{
    Task<IEnumerable<TEntity>> Get(string query, bool isProcedure = false);
    Task<IEnumerable<TEntity>> Get(string query, Dictionary<string, object> parameters, bool isProcedure = false);
    Task<TEntity> Single(string query, bool isProcedure = false);
    Task<TEntity> Single(string query, Dictionary<string, object> parameters, bool isProcedure = false);
}
