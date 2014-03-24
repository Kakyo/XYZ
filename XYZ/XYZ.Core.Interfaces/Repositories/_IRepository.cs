using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity: Entities.IEntity
    {
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> Read();
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
