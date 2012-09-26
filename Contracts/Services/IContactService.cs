using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IContactService
    {
        // create
        IContact CreateContact(string firstName, string lastName);
        IContact CreateContact<T>(T contact) where T : IIdentifiable;


        // get individual group
        IContact GetContact(Identifier groupIdentifier);
        T GetContact<T>(Identifier groupIdentifier) where T : IIdentifiable;

        // get all groups
        List<IContact> GetAllContacts();
        List<T> GetAllContacts<T>() where T : IIdentifiable;
    }
}
