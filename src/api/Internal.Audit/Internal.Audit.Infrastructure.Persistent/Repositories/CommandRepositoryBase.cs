
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Internal.Audit.Infrastructure.Persistent.Repositories;

public class CommandRepositoryBase<TEntity> : IAsyncCommandRepository<TEntity> where TEntity : EntityBase
{
    protected readonly InternalAuditContext _dbContext;

    public CommandRepositoryBase(InternalAuditContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await Task.CompletedTask;
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        var dbSet = _dbContext.Set<TEntity>();
        var entity = await dbSet.FindAsync(id);
        if(entity == null) return false;
        dbSet.Remove(entity);
        return true;
    }

    public async Task<IReadOnlyList<TEntity>> Get()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> Get(Guid id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IReadOnlyList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();
        if(disableTracking) query = query.AsNoTracking();

        if(predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await Task.CompletedTask;
        return entity;
    }
    public async Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        await _dbContext.AddRangeAsync(entity);
        return entity;
    }
    public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        _dbContext.UpdateRange(entity);
        await Task.CompletedTask;
        return entity;
    }

    public async Task<bool> Delete(IEnumerable<TEntity> entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        _dbContext.RemoveRange(entity);
        await Task.CompletedTask;
        return true;
    }
}
