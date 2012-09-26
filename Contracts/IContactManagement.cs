using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IContactManagment
    {
        IGroupService Groups { get; set; }
        IContactService Contacts { get; set; }
    }
}
