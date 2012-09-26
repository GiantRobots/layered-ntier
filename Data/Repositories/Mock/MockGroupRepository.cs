using Contracts.Domain;
using Contracts.Repositories;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Mock
{
    public class MockGroupRepository : IGroupRepository
    {
        List<IGroup> groups = new List<IGroup>();

        public void Add(IGroup entity)
        {
            entity.Id = new Identifier();
            groups.Add(entity);
        }

        public void Update(IGroup entity)
        {
            var group = groups.SingleOrDefault(g => g.Id == entity.Id);

            group.Name = entity.Name;
        }

        public IGroup Get(Identifier id)
        {
            return groups.SingleOrDefault(g => g.Id == id);
        }

        public List<IGroup> All()
        {
            return groups;
        }

        public bool Delete(Identifier id)
        {
            var group = groups.SingleOrDefault(g => g.Id == id);
            groups.Remove(group);
            return true;
        }
    }
}
