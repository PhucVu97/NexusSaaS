using NexusSaaS.Entity;
using NexusSaaS.Models;
using System.Collections.Generic;
using X.PagedList;

namespace NexusSaaS.Repository.Interface
{
    public interface IFeatureRepository : IGenericRepository<FeatureEntity, FeatureModel>
    {
        IPagedList<FeatureModel> PagedList(int? page, int? pageSize);
    }
}
