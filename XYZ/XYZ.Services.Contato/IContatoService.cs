using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Services.Contato
{
    [ServiceContract]
    public interface IContatoService
    {
        [OperationContract]
        bool Ping();

        [OperationContract]
        List<Domain.Contato> GetContatos(int take);
    }
}
