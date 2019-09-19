using AutoMapper;
using AutoMapper.QueryableExtensions;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using NexusSaaS.Ultil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusSaaS.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;
        private readonly StringUltil _stringUltil;

        public UserRepository(NexusSaaSDbContext context, IMapper mapper, StringUltil stringUltil)
        {
            _context = context;
            _mapper = mapper;
            _stringUltil = stringUltil;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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

        public UserModel GetByEmail(string email)
        {
            var obj = _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault(u => u.Email == email);

            if (obj != null)
            {
                return obj;
            }
            return null;
        }

        public UserModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            var obj = _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault(u => u.UserId == id);

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
                objEntity.Password = _stringUltil.EncryptPassword(objEntity.Password, objEntity.Salt);
                foreach (var roleId in objModel.RoleIds)
                {
                    var role = _context.Roles.Find(roleId);
                    if (role != null)
                    {
                        RoleUser roleUser = new RoleUser
                        {
                            Role = role,
                            UserEntity = objEntity
                        };
                        _context.Add(roleUser);
                    }
                }
                _context.Add(objEntity);
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
