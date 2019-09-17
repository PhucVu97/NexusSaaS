using AutoMapper;
using AutoMapper.QueryableExtensions;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusSaaS.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;

        public FeatureRepository(NexusSaaSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Features.Find(id);
                    if (obj != null)
                    {
                        _context.Remove(obj);
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public FeatureModel GetById(int id)
        {
            var obj = _context.Features
                .ProjectTo<FeatureModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault(f => f.Id == id);

            if(obj != null)
            {
                return obj;
            }
            return null;
        }

        public FeatureModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeatureModel> List()
        {
            var list = _context.Features
                .ProjectTo<FeatureModel>(_mapper.ConfigurationProvider)
                .ToList();

            if(list != null || list.Count() > 0)
            {
                return list;
            }
            return null;
        }

        public void Save(FeatureModel objModel)
        {
            if (objModel != null)
            {
                var objEntity = _mapper.Map<FeatureEntity>(objModel);
                _context.Features.Add(objEntity);
                _context.SaveChanges();
            }
        }

        public void Update(FeatureModel objModel)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (objModel != null)
                    {
                        var objEntity = _mapper.Map<FeatureEntity>(objModel);
                        _context.Update(objEntity);
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
