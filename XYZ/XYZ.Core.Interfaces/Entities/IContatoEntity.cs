using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Entities
{
    public interface IContatoEntity : IEntity
    {
        string Nome { get; set; }
        string Telefone { get; set; }
        string Celular { get; set; }
        DateTime? DataNascimento { get; set; }
    }
}
