using System.Linq.Expressions;

namespace DiaryUniverse.Infrastructure.Repositories;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(Guid? id);
    Task<T?> GetEntityAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetAllQueryable();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> expression);
    
    Task AddAsync(T entity);
    Task AddAsync(IEnumerable<T> entities);
    
    void Remove(T entity);
    void Remove(IEnumerable<T> entities);
    
    void Update(T entity);
    void Update(IEnumerable<T> entities);
    
    Task SaveAsync();
}