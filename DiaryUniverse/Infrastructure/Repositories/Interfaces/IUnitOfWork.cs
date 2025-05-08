using DiaryUniverse.Infrastructure.Data.Models;

namespace DiaryUniverse.Infrastructure.Repositories;

public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
}