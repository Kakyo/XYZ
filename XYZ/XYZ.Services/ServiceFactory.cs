using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Services
{
    internal static class ServiceFactory
    {
        static SrParceiro.ParceiroServiceClient _parceiroClient;
        public static SrParceiro.ParceiroServiceClient ParceiroService
        {
            get
            {
                return _parceiroClient = _parceiroClient ?? new SrParceiro.ParceiroServiceClient();
            }
        }

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
