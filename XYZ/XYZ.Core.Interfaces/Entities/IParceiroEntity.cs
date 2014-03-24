using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Entities
{
    public interface IParceiroEntity : IEntity
    {
        string Login { get; set; }
        string Senha { get; set; }
        string CpfCnpj { get; set; }
        long? IdResponsavel { get; set; }
        IParceiroEntity Responsavel { get; set; }
    }
}
