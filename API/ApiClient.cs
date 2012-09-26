using API.Services;
using Contracts;
using Contracts.Services;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ApiClient : IApiClient
    {
        RepositoryContext repositoryContext;


        private IContactService contacts;
        public IContactService Contacts
        {
            get
            {
                if (contacts == null)
                    contacts = new ContactService(repositoryContext);
                return contacts;
            }
            set
            {
                contacts = value;
            }
        }

        private IGroupService groups;
        public IGroupService Groups
        {
            get {
                if (groups == null)
                    groups = new GroupService(repositoryContext);
                return groups;
            }
            set
            {
                groups = value;
            }
        }
    }

}
