using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using XYZ.Utils.SampleData;

namespace XYZ.Repository.Dal
{
    internal class ContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        private const int _entries = 10000;

        protected override void Seed(Context context)
        {
            List<Domain.Contato> contatos = new List<Domain.Contato>(_entries);

            List<string> names = Generate.Name(_entries);
            List<string> phones = Generate.Phone(_entries);
            List<string> addresses = Generate.Address(_entries);

            object block = new object();
            Loops.Loop(0, _entries, i =>
            {
                var item = new Domain.Contato
                {
                    Telefone = phones[i],
                    Nome = names[i],
                    Endereco = addresses[i],
                    IdUserCreation = -1,
                    DtCreation = DateTime.Now,
                    IdUserModified = -1,
                    DtModified = DateTime.Now
                };
                lock (block)
                    contatos.Add(item);
            });

            context.Contatos.AddRange(contatos);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
