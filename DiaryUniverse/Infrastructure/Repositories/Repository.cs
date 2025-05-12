using System.Linq.Expressions;
using DiaryUniverse.Infrastructure.Data;
using DiaryUniverse.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryUniverse.Infrastructure.Repositories;

public class Repository<T> : IRepository<T>
    where T : Entity
{
    private readonly DiaryUniverseContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(DiaryUniverseContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    
    public async Task<T?> GetByIdAsync(Guid? id)
    {
        var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);
        if (entity != null)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }
        return entity;
    }

    public async Task<T?> GetEntityAsync(Expression<Func<T, bool>> expression)
    {
        return await GetAllQueryable(expression).FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await GetAllQueryable().ToListAsync().ConfigureAwait(false);
    }
    
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
    {
        return await GetAllQueryable(expression).ToListAsync().ConfigureAwait(false);
    }
    
    public IQueryable<T> GetAllQueryable()
    {
        return _dbSet.AsNoTracking();
    }

    public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression).AsNoTracking();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity).ConfigureAwait(false);
    }

    public async Task AddAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities).ConfigureAwait(false);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Remove(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Update(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
}