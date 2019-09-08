using Microsoft.EntityFrameworkCore;
using NexusSaaS.Models;
using System.Collections.Generic;
using System.Linq;

namespace NexusSaaS.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        private NexusSaaSDbContext context;
        private DbSet<TEntity> entity;
        public Repository(NexusSaaSDbContext context)
        {
            this.context = context;
            entity = context.Set<TEntity>();
        }

        public Repository() { }

        public void Delete(int id)
        {
            var obj = entity.Find(id);
            if(obj != null)
            {
                entity.Remove(obj);
            }
        }

        public TEntity GetById(int id)
        {
            var obj = entity.Find(id);
            return obj;
        }

        public IEnumerable<TEntity> List()
        {
            var list = entity.ToList();
            return list;
        }

        public void Save(TEntity obj)
        {
            if(obj != null)
            {
                entity.Add(obj);
            }
        }

        public void Update(TEntity obj)
        {
            if(obj != null)
            {
                entity.Update(obj);
            }
        }
    }
}
