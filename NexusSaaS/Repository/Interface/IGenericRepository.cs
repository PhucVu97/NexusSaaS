using System.Collections.Generic;
using System.Net;

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
        HttpStatusCode Save(TModel objModel);
        HttpStatusCode Update(TModel objModel);
        HttpStatusCode Delete(int id);
        HttpStatusCode Delete(string id);
        TModel GetById(int id);
        TModel GetById(string id);
    }
}
