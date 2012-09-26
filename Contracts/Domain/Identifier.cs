using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain
{
    public class Identifier
    {
        private Guid value;

        public Identifier()
        {
            value = Guid.NewGuid();
        }
        public Identifier(Guid guid)
        {
            value = new Guid(guid.ToByteArray());
        }
        public Identifier(string identifier)
        {
            value = Guid.Parse(identifier);
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
}
