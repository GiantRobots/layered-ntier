using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Group : IGroup
    {
        public Identifier Id { get; set; }
        public string Name { get; set; }       
    }
}
