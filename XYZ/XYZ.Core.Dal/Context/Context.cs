using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Dal
{
    public class Context : DbContext
    {
        public DbSet<Domain.Contato> Contatos { get; set; }
    }
}
