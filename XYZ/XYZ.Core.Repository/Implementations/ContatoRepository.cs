using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Repositories.Implementations
{
    public class ContatoRepository : Interfaces.Repositories.IContatoRepository
    {
        public Interfaces.Entities.IContatoEntity Create(Interfaces.Entities.IContatoEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interfaces.Entities.IContatoEntity> Read()
        {
            List<Domain.Contato> collection = new List<Domain.Contato>{
                new Domain.Contato() { Id = 1
                    , Nome ="Fulano da Silva"
                    , DataNascimento=DateTime.Now.AddYears(-25) },
                new Domain.Contato() { Id = 2
                    , Nome ="Ciclano da Silva"
                    , DataNascimento=DateTime.Now.AddYears(-21) }
            };
            return collection;
        }

        public Interfaces.Entities.IContatoEntity Update(Interfaces.Entities.IContatoEntity entity)
        {
            throw new NotImplementedException();
        }

        public Interfaces.Entities.IContatoEntity Delete(Interfaces.Entities.IContatoEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
