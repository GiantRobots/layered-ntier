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
    public class GroupServiceTest
    {
        RepositoryContext repositoryContext;

        IGroupService groupService;
        IContactService contactService;

        [SetUp]
        public void Setup()
        {
            repositoryContext = new RepositoryContext(new MockGroupRepository(), new MockContactRepository());
            groupService = (IGroupService)new GroupService(repositoryContext);
            contactService = (IContactService)new ContactService(repositoryContext);

            Mapper.CreateMap<Group, GroupViewModel>();
            Mapper.CreateMap<GroupViewModel, Group>();

            Mapper.CreateMap<Contact, ContactViewModel>();
        }

        [TearDown]
        public void TearDown()
        {
            groupService = null;
        }

        [Test]
        public void CreateGroup()
        {
            var group = groupService.CreateGroup("Test Group");
            Assert.IsNotNull(group);
            Assert.IsNotNull(group.Id);
            Assert.AreEqual("Test Group", group.Name);
        }

        [Test]
        public void CreateGroupFromT()
        {
            var newGroupMap = new GroupViewModel()
            {
                Name = "Test Group"
            };

            var group = groupService.CreateGroup<GroupViewModel>(newGroupMap);
            Assert.IsNotNull(group);
            Assert.IsNotNull(group.Id);
            Assert.AreEqual(newGroupMap.Name, group.Name);
        }

        [Test]
        public void RetrieveGroup()
        {
            var group = groupService.CreateGroup("Test Group");
            Assert.IsNotNull(group);
            Assert.IsNotNull(group.Id);
            Assert.AreEqual("Test Group", group.Name);

            var recentlyAddedGroup = groupService.GetGroup(group.Id);

            Assert.IsNotNull(recentlyAddedGroup);
            Assert.IsNotNull(recentlyAddedGroup.Id);
            Assert.AreEqual("Test Group", recentlyAddedGroup.Name);
        }

        [Test]
        public void RetrieveGroupFromT()
        {
            var group = groupService.CreateGroup("Test Group");
            Assert.IsNotNull(group);
            Assert.IsNotNull(group.Id);
            Assert.AreEqual("Test Group", group.Name);

            var recentlyAddedGroup = groupService.GetGroup<GroupViewModel>(group.Id);

            Assert.IsNotNull(recentlyAddedGroup);
            Assert.IsNotNull(recentlyAddedGroup.Id);
            Assert.AreEqual("Test Group", recentlyAddedGroup.Name);
        }

        [Test]
        public void RetrieveAllGroups()
        {
            var groupA = groupService.CreateGroup("Test Group A");
            var groupB = groupService.CreateGroup("Test Group B");

            var groups = groupService.GetAllGroups();

            Assert.IsNotNull(groups);
            Assert.IsTrue(groups.Count == 2);

            foreach (var group in groups)
            {
                Assert.IsNotNull(group.Id);
                Assert.IsTrue(group.Name.StartsWith("Test Group"));
            }
        }

        [Test]
        public void RetrieveAllGroupsFromT()
        {
            var groupA = groupService.CreateGroup("Test Group A");
            var groupB = groupService.CreateGroup("Test Group B");

            var groups = groupService.GetAllGroups<GroupViewModel>();

            Assert.IsNotNull(groups);
            Assert.IsTrue(groups.Count == 2);

            foreach (var group in groups)
            {
                Assert.IsNotNull(group.Id);
                Assert.IsTrue(group.Name.StartsWith("Test Group"));
            }
        }

        [Test(Description = "Makes sure that the AddContactToGroup method returns false if we try to add a contact to a group while they already exist in that group")]
        public void AddContactToGroup()
        {
            var group = groupService.CreateGroup("Test Group A");
            var contact = contactService.CreateContact("Joey", "Peters");

            bool result = groupService.AddContactToGroup(contact.Id, group.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public void AddExistingContactToGroup()
        {
            var group = groupService.CreateGroup("Test Group A");
            var contact = contactService.CreateContact("Joey", "Peters");

            bool resultA = groupService.AddContactToGroup(contact.Id, group.Id);

            Assert.IsTrue(resultA);

            bool resultB = groupService.AddContactToGroup(contact.Id, group.Id);
            Assert.IsFalse(resultB);

        }

        [Test]
        public void GetAllContactsInGroup()
        {
            var group = groupService.CreateGroup("Test Group A");
            var contactA = contactService.CreateContact("Joey A", "Peters");
            var contactB = contactService.CreateContact("Joey B", "Peters");

            groupService.AddContactToGroup(contactA.Id, group.Id);
            groupService.AddContactToGroup(contactB.Id, group.Id);

            var contacts = groupService.GetAllGroupContacts();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count == 2);

            foreach (var contact in contacts)
            {
                Assert.IsNotNull(contact.Id);
                Assert.IsTrue(contact.FirstName.StartsWith("Joey"));
            }
        }

        [Test]
        public void GetAllContactsInGroupFromT()
        {
            var group = groupService.CreateGroup("Test Group A");
            var contactA = contactService.CreateContact("Joey A", "Peters");
            var contactB = contactService.CreateContact("Joey B", "Peters");

            groupService.AddContactToGroup(contactA.Id, group.Id);
            groupService.AddContactToGroup(contactB.Id, group.Id);

            var contacts = groupService.GetAllGroupContacts<ContactViewModel>();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count == 2);

            foreach (var contact in contacts)
            {
                Assert.IsNotNull(contact.Id);
                Assert.IsTrue(contact.FirstName.StartsWith("Joey"));
            }
        }

        
    }
}
