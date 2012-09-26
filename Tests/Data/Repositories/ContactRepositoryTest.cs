using API.Services;
using Contracts.Domain;
using Contracts.Repositories;
using Data.Entities;
using Data.Repositories.Mock;
using NUnit.Framework;

namespace Tests.Data.Repositories
{
    [TestFixture]
    public class ContactRepositoryTest
    {
        IContactRepository contactRepository;

        [SetUp]
        public void Setup()
        {
            var mockRepo = new MockContactRepository();
            contactRepository = (IContactRepository)mockRepo;
        }

        [TearDown]
        public void TearDown()
        {
            contactRepository = null;
        }

        [Test]
        public void AddContact()
        {
            IContact contact = new Contact()
            {
                FirstName = "Contact"
            };

            contactRepository.Add(contact);

            Assert.IsNotNull(contact);
            Assert.IsNotNull(contact.Id);
            Assert.IsNotNull(contact.FirstName);
        }

        [Test]
        public void GetAddedContact()
        {
            IContact contact = new Contact()
            {
                FirstName = "Contact"
            };

            contactRepository.Add(contact);

            var retrievedContact = contactRepository.Get(contact.Id);

            Assert.IsNotNull(retrievedContact);
            Assert.IsNotNull(retrievedContact.Id);
            Assert.IsNotNull(retrievedContact.FirstName);

            Assert.AreEqual(retrievedContact.Id, contact.Id);
            Assert.AreEqual(retrievedContact.FirstName, contact.FirstName);
        }
        [Test]
        public void UpdateAddedContact()
        {
            IContact contact = new Contact()
            {
                FirstName = "Contact"
            };           

            contactRepository.Add(contact);

            IContact updatedContact = new Contact()
            {
                Id = contact.Id,
                FirstName = "Updated Contact"
            };

            contactRepository.Update(updatedContact);

            var retrievedUpdatedContact = contactRepository.Get(contact.Id);

            Assert.IsNotNull(retrievedUpdatedContact);
            Assert.IsNotNull(retrievedUpdatedContact.Id);
            Assert.IsNotNull(retrievedUpdatedContact.FirstName);

            Assert.AreEqual(retrievedUpdatedContact.Id, updatedContact.Id);
            Assert.AreEqual(retrievedUpdatedContact.FirstName, updatedContact.FirstName);
        }
        [Test]
        public void DeletedAddedContact()
        {
            IContact contact = new Contact()
            {
                FirstName = "Contact"
            };

            contactRepository.Add(contact);
            var deleted = contactRepository.Delete(contact.Id);

            Assert.IsTrue(deleted);

            var retrievedContact = contactRepository.Get(contact.Id);

            Assert.IsNull(retrievedContact);
        }
        [Test]
        public void GetAllAddedContact()
        {
            IContact contactA = new Contact()
            {
                FirstName = "Contact A"
            };

            IContact contactB = new Contact()
            {
                FirstName = "Contact B"
            };

            contactRepository.Add(contactA);
            contactRepository.Add(contactB);

            var contacts = contactRepository.All();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count == 2);

            foreach (var contact in contacts)
            {
                Assert.IsNotNull(contact);
                Assert.IsNotNull(contact.Id);
                Assert.IsNotNull(contact.FirstName);

                Assert.AreEqual(contact.Id, contact.Id);
                Assert.IsTrue(contact.FirstName.StartsWith("Contact"));
            }
           
        }
    }
}
