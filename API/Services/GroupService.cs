using AutoMapper;
using Contracts.Domain;
using Contracts.Repositories;
using Contracts.Services;
using Data.Repositories.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class GroupService : IGroupService
    {
        //IGroupRepository groupRepository;
        IRepositoryContext repositoryContext;

        Dictionary<Identifier, List<IContact>> contactsToGroupId = new Dictionary<Identifier, List<IContact>>();

        public GroupService(IRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            //groupRepository = new MockGroupRepository();
        }

        public IGroup CreateGroup(string name)
        {
            var group = new Group()
            {
                Name = name
            };

            repositoryContext.Groups.Add(group);

            return group;
        }

        public IGroup CreateGroup<T>(T groupMapping) where T : IIdentifiable
        {
            var group = Mapper.Map<Group>(groupMapping);

            repositoryContext.Groups.Add(group);

            return group;
        }

        public IGroup GetGroup(Identifier groupIdentifier)
        {
            return repositoryContext.Groups.Get(groupIdentifier);
        }

        public T GetGroup<T>(Identifier groupIdentifier) where T : IIdentifiable
        {
            return Mapper.Map<T>(repositoryContext.Groups.Get(groupIdentifier));
        }

        public List<IGroup> GetAllGroups()
        {
            return repositoryContext.Groups.All();
        }

        public List<T> GetAllGroups<T>() where T : IIdentifiable
        {
            return Mapper.Map<List<T>>(repositoryContext.Groups.All());
        }

        public bool AddContactToGroup(Identifier contactIdentifier, Identifier groupIdentifier)
        {
            if (!contactsToGroupId.ContainsKey(groupIdentifier))
                contactsToGroupId[groupIdentifier] = new List<IContact>();

            if (!contactsToGroupId[groupIdentifier].Any(u => u.Id == contactIdentifier))
            {
                contactsToGroupId[groupIdentifier].Add(repositoryContext.Contacts.Get(contactIdentifier));
                return true;
            }
            return false;
        }


        public List<IContact> GetAllGroupContacts()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllGroupContacts<T>() where T : IIdentifiable
        {
            throw new NotImplementedException();
        }
    }
    public class Group : IGroup
    {
        public Identifier Id { get; set; }
        public string Name { get; set; }
    }
}
