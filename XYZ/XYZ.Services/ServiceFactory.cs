using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Services
{
    internal static class ServiceFactory
    {

        static SrContato.ContatoServiceClient _contatoClient;
        public static SrContato.ContatoServiceClient ContatoService
        {
            get
            {
                return _contatoClient = _contatoClient ?? new SrContato.ContatoServiceClient();
            }
        }
    }
}
