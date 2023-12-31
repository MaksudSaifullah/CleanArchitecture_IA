﻿
using Internal.Audit.Domain.Common;
using System.Linq.Expressions;

namespace Internal.Audit.Application.Contracts.Persistent;

public interface IAsyncCommandRepository<TEntity> where TEntity : EntityBase
{
    Task<IReadOnlyList<TEntity>> Get();
    Task<TEntity> Get(Guid id);
    Task<IReadOnlyList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
    Task<IReadOnlyList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate=null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy =null, params Expression<Func<TEntity, object>>[] includes);
    Task<IReadOnlyList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        bool disableTracking = true);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<bool> Delete(TEntity entity);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entity);
    Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entity);
    Task<bool> Delete(IEnumerable<TEntity> entity);


}