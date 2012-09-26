using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRepository<T> where T : IIdentifiable
    {
        void Add(T entity);
        void Update(T entity);
        T Get(Identifier id);
        List<T> All();
        bool Delete(Identifier id);
    }
}
