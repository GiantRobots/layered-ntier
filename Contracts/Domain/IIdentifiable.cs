using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain
{
    public interface IIdentifiable
    {
        Identifier Id { get; set; }
    }
}
