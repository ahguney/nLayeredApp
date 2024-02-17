using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity,TId>
        where TEntity : Entity<TId>
    {
        IList<TEntity> GetList();
        TEntity Get(TId id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity, bool isSoftDelete=true);
    }
}
