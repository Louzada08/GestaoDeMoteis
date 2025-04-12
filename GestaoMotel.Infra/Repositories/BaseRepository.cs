using AutoMapper;
using GestaoMotel.Domain.Entities.Base;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestaoMotel.Infra.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
{
    public AppDbContext Context { get; }
    public IUnitOfWork UnitOfWork { get; set; }
    protected readonly DbSet<TEntity> DbSet;
    private readonly IMapper _mapper;

    public BaseRepository(AppDbContext context, IMapper mapper)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
        this.UnitOfWork = Context as IUnitOfWork;
        _mapper = mapper;
    }

    public TEntity Add(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.CreatedAt = DateTime.UtcNow;
            baseEntity.UpdatedAt = DateTime.UtcNow;
        }

        DbSet.Add(entity);
        return entity;
    }

    public TEntity Remove(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.DeletedAt = DateTime.UtcNow;
            DbSet.Update(entity);
        }
        else
        {
            DbSet.Remove(entity);
        }

        return entity;
    }

    public TEntity FindById(params object[] ids)
    {
        return DbSet.Find(ids);
    }

    public virtual TEntity Update(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.UpdatedAt = DateTime.UtcNow;
        }

        var entry = Context.Entry(entity);
        DbSet.Attach(entity);
        entry.State = EntityState.Modified;

        return entity;
    }

    public IQueryable<TEntity> QueryableFilter() => DbSet.AsQueryable();

    public IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria = null, bool @readonly = false, params Expression<Func<TEntity, object>>[] includes)
    {
        if (criteria == null)
        {
            if (includes == null)
            {
                return DbSet.Where(criteria);
            }

            var queryAll = DbSet.AsQueryable();

            foreach (var include in includes)
            {
                queryAll.Include(include);
            }

            return @readonly ? queryAll.AsNoTracking() : queryAll;
        }
        var queryWhere = DbSet.Where(criteria);

        if (includes == null)
        {
            return queryWhere;
        }

        foreach (var include in includes)
        {
            queryWhere = queryWhere.Include(include);
        }

        return queryWhere;
    }

    #region IDisposable

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;

        Context.Dispose();
    }

    #endregion IDisposable
}
