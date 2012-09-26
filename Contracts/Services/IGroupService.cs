using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IGroupService
    {
        // create
        IGroup CreateGroup(string name);
        IGroup CreateGroup<T>(T group) where T : IIdentifiable;

        // get individual group
        IGroup GetGroup(Identifier groupIdentifier);
        T GetGroup<T>(Identifier groupIdentifier) where T : IIdentifiable;

        // get all groups
        List<IGroup> GetAllGroups();
        List<T> GetAllGroups<T>() where T : IIdentifiable;

        // business logic methods
        bool AddContactToGroup(Identifier contactIdentifier, Identifier groupIdentifier);

        List<IContact> GetAllGroupContacts();
        List<T> GetAllGroupContacts<T>() where T : IIdentifiable;

    }
}
