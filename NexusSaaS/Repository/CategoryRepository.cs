using AutoMapper;
using AutoMapper.QueryableExtensions;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NexusSaaS.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository (NexusSaaSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public HttpStatusCode Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Categories.Find(id);
                    if (obj != null)
                    {
                        _context.Remove(obj);
                        _context.SaveChanges();
                        transaction.Commit();
                        return HttpStatusCode.OK;
                    }
                    return HttpStatusCode.NotFound;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return HttpStatusCode.InternalServerError;
                }
            }
        }

        public HttpStatusCode Delete(string id)
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetById(int id)
        {
            var obj = _context.Categories
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault(f => f.CategoryId == id);

            if (obj != null)
            {
                return obj;
            }
            return null;
        }

        public CategoryModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> List()
        {
            var list = _context.Categories
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
                .ToList();

            if (list != null || list.Count() > 0)
            {
                return list;
            }
            return null;
        }

        public HttpStatusCode Save(CategoryModel objModel)
        {
            if (objModel != null)
            {
                try
                {
                    var objEntity = _mapper.Map<Category>(objModel);
                    _context.Categories.Add(objEntity);
                    _context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                catch
                {
                    return HttpStatusCode.InternalServerError;
                }
            }
            return HttpStatusCode.BadRequest;
        }

        public HttpStatusCode Update(CategoryModel objModel)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (objModel != null)
                    {
                        var objEntity = _mapper.Map<Category>(objModel);
                        _context.Update(objEntity);
                        _context.SaveChanges();
                        transaction.Commit();
                        return HttpStatusCode.OK;
                    }
                    return HttpStatusCode.BadRequest;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return HttpStatusCode.InternalServerError;
                }
            }
        }
    }
}
