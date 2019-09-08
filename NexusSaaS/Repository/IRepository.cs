using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> List();
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
    }
}
