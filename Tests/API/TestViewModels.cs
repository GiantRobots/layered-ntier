using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.API
{
    public class GroupViewModel : IIdentifiable
    {
        public Identifier Id { get; set; }
        public string Name { get; set; }
    }

    public class ContactViewModel : IIdentifiable
    {
        public Identifier Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
