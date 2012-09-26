using Contracts.Domain;
using Contracts.Repositories;
using Data.Entities;
using Data.Repositories.Mock;
using NUnit.Framework;

namespace Tests.Data.Repositories
{
    [TestFixture]
    public class GroupRepositoryTest
    {
        IGroupRepository groupRepository;

        [SetUp]
        public void Setup()
        {
            var mockRepo = new MockGroupRepository();
            groupRepository = (IGroupRepository)mockRepo;
        }

        [TearDown]
        public void TearDown()
        {
            groupRepository = null;
        }

        [Test]
        public void AddGroup()
        {
            IGroup group = new Group()
            {
                Name = "Group"
            };

            groupRepository.Add(group);

            Assert.IsNotNull(group);
            Assert.IsNotNull(group.Id);
            Assert.IsNotNull(group.Name);
        }

        [Test]
        public void GetAddedGroup()
        {
            IGroup group = new Group()
            {
                Name = "Group"
            };

            groupRepository.Add(group);

            var retrievedGroup = groupRepository.Get(group.Id);

            Assert.IsNotNull(retrievedGroup);
            Assert.IsNotNull(retrievedGroup.Id);
            Assert.IsNotNull(retrievedGroup.Name);

            Assert.AreEqual(retrievedGroup.Id, group.Id);
            Assert.AreEqual(retrievedGroup.Name, group.Name);
        }
        [Test]
        public void UpdateAddedGroup()
        {
            IGroup group = new Group()
            {
                Name = "Group"
            };           

            groupRepository.Add(group);

            IGroup updatedGroup = new Group()
            {
                Id = group.Id,
                Name = "Updated Group"
            };

            groupRepository.Update(updatedGroup);

            var retrievedUpdatedGroup = groupRepository.Get(group.Id);

            Assert.IsNotNull(retrievedUpdatedGroup);
            Assert.IsNotNull(retrievedUpdatedGroup.Id);
            Assert.IsNotNull(retrievedUpdatedGroup.Name);

            Assert.AreEqual(retrievedUpdatedGroup.Id, updatedGroup.Id);
            Assert.AreEqual(retrievedUpdatedGroup.Name, updatedGroup.Name);
        }
        [Test]
        public void DeletedAddedGroup()
        {
            IGroup group = new Group()
            {
                Name = "Group"
            };

            groupRepository.Add(group);
            var deleted = groupRepository.Delete(group.Id);

            Assert.IsTrue(deleted);

            var retrievedGroup = groupRepository.Get(group.Id);

            Assert.IsNull(retrievedGroup);
        }
        [Test]
        public void GetAllAddedGroup()
        {
            IGroup groupA = new Group()
            {
                Name = "Group A"
            };

            IGroup groupB = new Group()
            {
                Name = "Group B"
            };

            groupRepository.Add(groupA);
            groupRepository.Add(groupB);

            var groups = groupRepository.All();

            Assert.IsNotNull(groups);
            Assert.IsTrue(groups.Count == 2);

            foreach (var group in groups)
            {
                Assert.IsNotNull(group);
                Assert.IsNotNull(group.Id);
                Assert.IsNotNull(group.Name);

                Assert.AreEqual(group.Id, group.Id);
                Assert.IsTrue(group.Name.StartsWith("Group"));
            }
           
        }
    }
}
