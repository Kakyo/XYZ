using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Services.Clients
{
    public class ParceiroClient : Interfaces.Services.IParceiroService
    {
        public bool Ping()
        {
            return ServiceFactory.ParceiroService.Ping();
        }
    }
}
