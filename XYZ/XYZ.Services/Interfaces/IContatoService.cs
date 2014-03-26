using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using XYZ.Interfaces.Entities;

namespace XYZ.Interfaces.Services
{
    public interface IContatoService : IService
    {
        IEnumerable<IContatoEntity> GetContatos(int take, int skip);
        IContatoEntity UpdateContato(long idContato, string celular, DateTime dataNasc);
    }
}
