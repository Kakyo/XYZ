using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.Repository.Dal
{
    internal class Context : DbContext
    {
        public Context()
            : base("EmpresaXYZ") { }

        public bool Transaction(Action<Context> exec)
        {
            using (var scope = this.Database.BeginTransaction())
            {
                try
                {
                    exec(this);
                    this.SaveChanges();
                    scope.Commit();
                    return true;
                }
                catch
                {
                    scope.Rollback();
                    return false;
                }
            }
        }

        public TResult Transaction<TResult>(Func<Context, TResult> exec)
        {
            TResult result = default(TResult);
            using (var scope = this.Database.BeginTransaction())
            {
                try
                {
                    result = exec(this);
                    this.SaveChanges();
                    scope.Commit();
                }
                catch
                {
                    scope.Rollback();
                }
            }
            return result;
        }

        public DbSet<Domain.Contato> Contatos { get; set; }
    }
}
