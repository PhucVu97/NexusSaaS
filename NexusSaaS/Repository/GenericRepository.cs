using Microsoft.EntityFrameworkCore;
using NexusSaaS.Data;
using NexusSaaS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NexusSaaS.Repository
{
    /// <summary>
    /// generic CRUD repository  
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository
    //    <TEntity> : IGenericRepository<TEntity, TModel> where TEntity : class
    {

        //    #region DIs
        //    private NexusSaaSDbContext context;
        //    private DbSet<TEntity> entity;
        //    public GenericRepository(NexusSaaSDbContext context)
        //    {
        //        this.context = context;
        //        entity = context.Set<TEntity>();
        //    }
        //    #endregion

        //    #region CRUD
        //    //public IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeExpressions)
        //    //{
        //    //    IQueryable<TEntity> query = null;
        //    //    foreach (var includeExpression in includeExpressions)
        //    //    {
        //    //        query = entity.Include(includeExpression);
        //    //    }
        //    //    return query ?? entity;
        //    //}


        //    public void Delete(int id)
        //    {
        //        var obj = entity.Find(id);
        //        if (obj != null)
        //        {
        //            entity.Remove(obj);
        //            context.SaveChanges();
        //        }
        //    }

        //    public void Delete(string id)
        //    {
        //        var obj = entity.Find(id);
        //        if (obj != null)
        //        {
        //            entity.Remove(obj);
        //            context.SaveChanges();
        //        }
        //    }

        //    public TEntity GetById(int id)
        //    {
        //        var obj = entity.Find(id);
        //        return obj;
        //    }

        //    public TEntity GetById(string id)
        //    {
        //        var obj = entity.Find(id);
        //        return obj;
        //    }

        //    public IEnumerable<TEntity> List()
        //    {
        //        var list = entity.ToList();
        //        return list;
        //    }

        //    public void Save(TEntity obj)
        //    {
        //        if (obj != null)
        //        {
        //            entity.Add(obj);
        //            context.SaveChanges();
        //        }
        //    }

        //    public void Update(TEntity obj)
        //    {
        //        if (obj != null)
        //        {
        //            entity.Update(obj);
        //            context.SaveChanges();
        //        }
        //    }
        //}
        //#endregion
    }
}

