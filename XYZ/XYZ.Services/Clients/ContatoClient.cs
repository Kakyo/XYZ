using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZ.Interfaces.Entities;

namespace XYZ.Services.Clients
{
    public class ContatoClient : Interfaces.Services.IContatoService
    {
        public bool Ping()
        {
            return ServiceFactory.ContatoService.Ping();
        }
        public IEnumerable<IContatoEntity> GetContatos(int take, int skip)
        {
            return ServiceFactory.ContatoService
                .GetContatos(take, skip);
        }
        public IContatoEntity UpdateContato(long idContato, string celular, DateTime dataNasc)
        {
            return (IContatoEntity)ServiceFactory.ContatoService
                .UpdateContato(idContato, celular, dataNasc);
        }
    }
}
