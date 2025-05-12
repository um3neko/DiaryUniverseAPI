using DiaryUniverse.Infrastructure.Data;
using DiaryUniverse.Infrastructure.Data.Models;

namespace DiaryUniverse.Infrastructure.Repositories;

public class UnitOfWork(DiaryUniverseContext  context, IServiceProvider serviceProvider) : IUnitOfWork
{
    private readonly DiaryUniverseContext  _context = context;

    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : Entity
    {
        var repository = serviceProvider.GetRequiredService<IRepository<TEntity>>();
        return repository;
    }
}