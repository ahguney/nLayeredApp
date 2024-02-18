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
        private readonly TDbContext _context;

        public EfRepositoryBase(TDbContext context)
        {
            this._context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            //Context.Entry(entity).State = EntityState.Added;

                _context.Add(entity);

            _context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;

            //Context.Entry(entity).State = EntityState.Deleted;

            if (!isSoftDelete)
                _context.Remove(entity);

            _context.SaveChanges();
            return entity;
        }

        public TEntity? Get(Func<TEntity,bool>? predicate=null)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IList<TEntity> GetList(Func<TEntity, bool>? predicate=null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

            if(predicate is not null)
            {
                query = _context.Set<TEntity>().Where(predicate).AsQueryable();
            }
            return query.ToList();  
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            //Context.Entry(entity).State = EntityState.Modified;

                _context.Update(entity);

            _context.SaveChanges();
            return entity;
        }
    }
}
