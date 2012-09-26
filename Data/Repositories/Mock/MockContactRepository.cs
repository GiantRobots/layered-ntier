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
    public class MockContactRepository : IContactRepository
    {
        List<IContact> contacts = new List<IContact>();

        public void Add(IContact entity)
        {
            entity.Id = new Identifier();
            contacts.Add(entity);
        }

        public void Update(IContact entity)
        {
            var contact = contacts.SingleOrDefault(g => g.Id == entity.Id);

            contact.FirstName = entity.FirstName;
            contact.LastName = entity.LastName;
        }

        public IContact Get(Identifier id)
        {
            return contacts.SingleOrDefault(g => g.Id == id);
        }

        public List<IContact> All()
        {
            return contacts;
        }

        public bool Delete(Identifier id)
        {
            var contact = contacts.SingleOrDefault(g => g.Id == id);
            contacts.Remove(contact);
            return true;
        }
    }
}
