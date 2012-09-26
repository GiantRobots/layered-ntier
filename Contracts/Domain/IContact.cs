using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain
{
    public interface IContact : IIdentifiable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        List<string> EmailAddress { get; set; }
    }
}
