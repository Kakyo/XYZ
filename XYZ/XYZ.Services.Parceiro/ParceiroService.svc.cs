using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace XYZ.Services.Parceiro
{
    public class ParceiroService : IParceiroService
    {
        public bool Ping()
        {
            return true;
        }
    }
}
