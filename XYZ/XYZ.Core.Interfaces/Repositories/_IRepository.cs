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
        IEnumerable<TEntity> Read(int take, int skip);
    }
}
