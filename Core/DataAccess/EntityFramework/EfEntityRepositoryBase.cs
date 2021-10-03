using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
  public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
  {
    public TEntity Add(TEntity entity)
    {
      using (TContext context = new TContext())
      {
        context.Add(entity);
        context.SaveChanges();
        return entity;
      }
    }

    public void Delete(TEntity entity)
    {
      using (TContext context = new TContext())
      {
        context.Remove(entity);
        context.SaveChanges();
      }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
      using (TContext context = new TContext())
      {
        return context.Set<TEntity>().FirstOrDefault(filter);
      }
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
      using (TContext context = new TContext())
      {
        return filter == null
          ? context.Set<TEntity>().ToList()
          : context.Set<TEntity>().Where(filter).ToList();
      }
    }

    public TEntity Update(TEntity entity)
    {
      using (TContext context = new TContext())
      {
        context.Update(entity);
        context.SaveChanges();
        return entity;
      }
    }
  }
}
