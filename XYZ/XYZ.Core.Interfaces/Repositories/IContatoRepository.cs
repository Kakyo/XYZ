using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Repositories
{
    public interface IContatoRepository : IRepository<Entities.IContatoEntity>
    {
        new Entities.IContatoEntity Update(long idContato, string celular, DateTime dataNasc);
    }
}
