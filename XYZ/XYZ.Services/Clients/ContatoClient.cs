using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Services.Clients
{
    public class ContatoClient : Interfaces.Services.IContatoService
    {
        public bool Ping()
        {
            return ServiceFactory.ContatoService.Ping();
        }
        public List<Domain.Contato> GetContatos(int take)
        {
            return ServiceFactory.ContatoService.GetContatos(take);
        }
    }
}
