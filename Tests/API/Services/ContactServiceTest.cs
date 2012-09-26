using API;
using API.Services;
using AutoMapper;
using Contracts;
using Contracts.Domain;
using Contracts.Services;
using Data.Repositories;
using Data.Repositories.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.API.Services
{
    [TestFixture]
    public class ContactServiceTest
    {
        RepositoryContext repositoryContext;

        IContactService contactService;

        [SetUp]
        public void Setup()
        {
            repositoryContext = new RepositoryContext(new MockGroupRepository(), new MockContactRepository());
            contactService = (IContactService)new ContactService(repositoryContext);

            Mapper.CreateMap<Contact, ContactViewModel>();
            Mapper.CreateMap<ContactViewModel, Contact>();
        }

        [TearDown]
        public void TearDown()
        {
            contactService = null;
        }

        [Test]
        public void CreateContact()
        {
            var contact = contactService.CreateContact("Joey", "Peters");
            Assert.IsNotNull(contact);
            Assert.IsNotNull(contact.Id);
            Assert.AreEqual("Joey", contact.FirstName);
            Assert.AreEqual("Peters", contact.LastName);
        }

        [Test]
        public void CreateContactFromT()
        {
            var newContactMap = new ContactViewModel()
            {
                FirstName = "Joey",
                LastName = "Peters"
            };

            var contact = contactService.CreateContact<ContactViewModel>(newContactMap);
            Assert.IsNotNull(contact);
            Assert.IsNotNull(contact.Id);
            Assert.AreEqual(newContactMap.FirstName, contact.FirstName);
            Assert.AreEqual(newContactMap.LastName, contact.LastName);
        }

        [Test]
        public void RetrieveContact()
        {
            var contact = contactService.CreateContact("Joey", "Peters");
            Assert.IsNotNull(contact);
            Assert.IsNotNull(contact.Id);
            Assert.AreEqual("Joey", contact.FirstName);

            var recentlyAddedContact = contactService.GetContact(contact.Id);

            Assert.IsNotNull(recentlyAddedContact);
            Assert.IsNotNull(recentlyAddedContact.Id);
            Assert.AreEqual("Joey", recentlyAddedContact.FirstName);
        }

        [Test]
        public void RetrieveContactFromT()
        {
            var contact = contactService.CreateContact("Joey", "Peters");
            Assert.IsNotNull(contact);
            Assert.IsNotNull(contact.Id);
            Assert.AreEqual("Joey", contact.FirstName);

            var recentlyAddedContact = contactService.GetContact<ContactViewModel>(contact.Id);

            Assert.IsNotNull(recentlyAddedContact);
            Assert.IsNotNull(recentlyAddedContact.Id);
            Assert.AreEqual("Joey", recentlyAddedContact.FirstName);
        }

        [Test]
        public void RetrieveAllContacts()
        {
            var contactA = contactService.CreateContact("Joey A", "Peters");
            var contactB = contactService.CreateContact("Joey B", "Peters");

            var contacts = contactService.GetAllContacts();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count == 2);

            foreach (var contact in contacts)
            {
                Assert.IsNotNull(contact.Id);
                Assert.IsTrue(contact.FirstName.StartsWith("Joey"));
                Assert.AreEqual(contact.LastName, "Peters");
            }
        }

        [Test]
        public void RetrieveAllContactsFromT()
        {
            var contactA = contactService.CreateContact("Joey A", "Peters");
            var contactB = contactService.CreateContact("Joey B", "Peters");

            var contacts = contactService.GetAllContacts<ContactViewModel>();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count == 2);

            foreach (var contact in contacts)
            {
                Assert.IsNotNull(contact.Id);
                Assert.IsTrue(contact.FirstName.StartsWith("Joey"));
                Assert.AreEqual(contact.LastName, "Peters");
            }
        }

        
    }
}
