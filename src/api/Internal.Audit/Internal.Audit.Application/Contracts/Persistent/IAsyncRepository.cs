
using Internal.Audit.Domain.Common;
using System.Linq.Expressions;

namespace Internal.Audit.Application.Contracts.Persistent;

public interface IAsyncRepository<T> where T : EntityBase
{
    Task<IReadOnlyList<T>> Get();
    Task<T> Get(long id);
    Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
        bool disableTracking = true);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(T entity);
    Task<bool> Delete(long id);
}