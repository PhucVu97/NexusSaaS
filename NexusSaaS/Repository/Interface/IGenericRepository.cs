using System.Collections.Generic;

namespace NexusSaaS.Repository.Interface
{
    /// <summary>
    /// interface generic CRUD repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity, TModel> 
        where TEntity : class
        where TModel : class
    {
        IEnumerable<TModel> List();
        void Save(TModel objModel);
        void Update(TModel objModel);
        void Delete(int id);
        void Delete(string id);
        TModel GetById(int id);
        TModel GetById(string id);
    }
}
