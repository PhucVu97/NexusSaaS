using NexusSaaS.Entity;
using NexusSaaS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Repository.Interface
{
    public interface ICategory : IGenericRepository<Category, CategoryModel>
    {
    }
}
