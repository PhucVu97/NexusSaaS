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
    public class UserRepository : IUserRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(NexusSaaSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Users.Find(id);
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

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(string id)
        {
            var obj = _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault(u => u.Id == id);

            if (obj != null)
            {
                return obj;
            }
            return null;
        }

        public IEnumerable<UserModel> List()
        {
            var list = _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .ToList();

            if (list != null || list.Count() > 0)
            {
                return list;
            }
            return null;
        }

        public void Save(UserModel objModel)
        {
            if (objModel != null)
            {
                var objEntity = _mapper.Map<UserEntity>(objModel);
                _context.Users.Add(objEntity);
                _context.SaveChanges();
            }
        }

        public void Update(UserModel objModel)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (objModel != null)
                    {
                        var objEntity = _mapper.Map<UserEntity>(objModel);
                        _context.Update(objEntity);
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
    }
}
