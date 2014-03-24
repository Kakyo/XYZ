using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Dal.Context
{
    public class Context : DbContext
    {
        public DbSet<Domain.Contato> Contatos { get; set; }
        public DbSet<Domain.Parceiro> Parceiros { get; set; }
    }
}
