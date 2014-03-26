using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using XYZ.Interfaces.Entities;
using XYZ.Interfaces.Repositories;

namespace XYZ.Repository.Implementations
{
    internal class ContatoRepository : IContatoRepository
    {
        private readonly Dal.Context _dbContext;
        public ContatoRepository(Dal.Context dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<IContatoEntity> Read(int take, int skip)
        {
            return this._dbContext.Transaction(scope =>
            {
                var dbSet = this._dbContext.Contatos
                    .AsNoTracking()
                    .AsQueryable();

                if (take > 0)
                    dbSet = dbSet.OrderBy(o => o.Id).Skip(skip).Take(take);

                return dbSet;
            });
        }

        public IContatoEntity Update(long idContato, string celular, DateTime dataNasc)
        {
            return this._dbContext.Transaction(scope =>
            {
                IContatoEntity contato = scope.Contatos.Find(idContato);
                contato.Celular = celular;
                contato.DataNascimento = dataNasc;
                contato.DtModified = DateTime.Now;
                return contato;
            });
        }

    }
}
