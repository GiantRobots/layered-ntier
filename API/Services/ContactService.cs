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
    public class ContactService : IContactService
    {
        //IContactRepository contactRepository;
        IRepositoryContext repositoryContext;

        public ContactService(IRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            //contactRepository = new MockContactRepository();
        }

        public Contracts.Domain.IContact CreateContact(string firstName, string lastName)
        {
            var contact = new Contact()
            {
                FirstName = firstName,
                LastName = lastName,
            };
            repositoryContext.Contacts.Add(contact);

            return contact;
        }

        public Contracts.Domain.IContact CreateContact<T>(T contactMapping) where T : IIdentifiable
        {
            var contact = Mapper.Map<Contact>(contactMapping);

            repositoryContext.Contacts.Add(contact);

            return contact;
        }

        public Contracts.Domain.IContact GetContact(Contracts.Domain.Identifier contactIdentifier)
        {
            return repositoryContext.Contacts.Get(contactIdentifier);
        }

        public T GetContact<T>(Contracts.Domain.Identifier contactIdentifier) where T : IIdentifiable
        {
            return Mapper.Map<T>(repositoryContext.Contacts.Get(contactIdentifier));
        }

        public List<Contracts.Domain.IContact> GetAllContacts()
        {
            return repositoryContext.Contacts.All();
        }

        public List<T> GetAllContacts<T>() where T : IIdentifiable
        {
            return Mapper.Map<List<T>>(repositoryContext.Contacts.All());
        }
    }
    public class Contact : IContact
    {
        public Identifier Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> EmailAddress { get; set; }
    }
}
