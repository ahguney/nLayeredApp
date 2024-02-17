using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TDbContext, TId> : IEntityRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TDbContext : DbContext
    {
        private readonly TDbContext Context;

        public EfRepositoryBase(TDbContext context)
        {
            this.Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            //Context.Entry(entity).State = EntityState.Added;

                Context.Add(entity);

            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;

            //Context.Entry(entity).State = EntityState.Deleted;

            if (!isSoftDelete)
                Context.Remove(entity);

            Context.SaveChanges();
            return entity;
        }

        public TEntity Get(TId id)
        {
                
            return Context.Set<TEntity>().FirstOrDefault(p=>p.Id.Equals(id));
        }

        public IList<TEntity> GetList()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            //Context.Entry(entity).State = EntityState.Modified;

                Context.Update(entity);

            Context.SaveChanges();
            return entity;
        }
    }
}
