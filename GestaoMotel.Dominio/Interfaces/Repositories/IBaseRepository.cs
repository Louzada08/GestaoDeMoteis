using System.Linq.Expressions;

namespace GestaoMotel.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    IUnitOfWork UnitOfWork { get; }
    TEntity Add(TEntity entity);
    TEntity FindById(params object[] keyValues);
    TEntity Update(TEntity entity);
    TEntity Remove(TEntity entity);
    IQueryable<TEntity> QueryableFilter();
    IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria = null,
        bool @readonly = false, params Expression<Func<TEntity, object>>[] includes);
}
