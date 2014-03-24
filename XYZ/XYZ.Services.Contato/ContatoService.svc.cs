using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace XYZ.Services.Contato
{
    public class ContatoService : IContatoService
    {
        public bool Ping()
        {
            return true;
        }

        public List<Domain.Contato> GetContatos(int take)
        {
            return XYZ.Repositories.RepositoryFactory.ContatoRepository
                .Read()
                .Cast<Domain.Contato>()
                .ToList();
        }

    }
}
