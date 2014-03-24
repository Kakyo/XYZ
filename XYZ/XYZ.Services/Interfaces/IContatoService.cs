using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Services
{
    public interface IContatoService : IService
    {
        List<Domain.Contato> GetContatos(int take);
    }
}
