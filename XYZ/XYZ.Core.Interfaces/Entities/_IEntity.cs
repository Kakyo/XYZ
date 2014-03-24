
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Entities
{
    public interface IEntity
    {
        long Id { get; set; }

        DateTime DtCreation { get; set; }
        long IdUserCreation { get; set; }

        DateTime DtModified { get; set; }
        long IdUserModified { get; set; }
    }
}
