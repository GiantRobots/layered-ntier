using Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryContext : IRepositoryContext
    {
        private IGroupRepository groups;
        public IGroupRepository Groups
        {
            get { return groups; }
            set { groups = value; }
        }

        private IContactRepository contacts;
        public IContactRepository Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        public RepositoryContext()
        {

        }
        public RepositoryContext(IGroupRepository groups, IContactRepository contacts)
        {
            this.groups = groups;
            this.contacts = contacts;
        }
    }
}
