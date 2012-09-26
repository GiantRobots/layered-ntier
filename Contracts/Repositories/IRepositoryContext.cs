using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRepositoryContext
    {
        IGroupRepository Groups { get; set; }
        IContactRepository Contacts { get; set; }
    }
}
