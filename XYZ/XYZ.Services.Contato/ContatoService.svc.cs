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

        public List<Domain.Contato> GetContatos(int take, int skip)
        {
            return XYZ.Repository.RepositoryFactory
                .ContatoRepository
                .Read(take, skip)
                .Select(s=>(Domain.Contato)s)
                .ToList();
        }
        public Domain.Contato UpdateContato(long idContato, string celular, DateTime dataNasc)
        {
            return (Domain.Contato)XYZ.Repository.RepositoryFactory
                .ContatoRepository
                .Update(idContato, celular, dataNasc);
        }
    }
}
