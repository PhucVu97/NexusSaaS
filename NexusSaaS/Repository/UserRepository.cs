using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using NexusSaaS.Ultil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NexusSaaS.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;
        private readonly StringUltil _stringUltil;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UserRepository(NexusSaaSDbContext context, IMapper mapper, StringUltil stringUltil, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _stringUltil = stringUltil;
            _httpContextAccessor = httpContextAccessor;
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

        public HttpStatusCode Login(UserModel user)
        {
            var existUser = _context.Users
               .Where(a => a.Status != Entity.AccountStatus.Deactive)
               .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
               .SingleOrDefault(u => u.Email == user.Email);

            if (existUser != null)
            {
                user.Password = _stringUltil.EncryptPassword(user.Password, existUser.Salt);
                if (existUser.Password == user.Password && existUser.Status == Models.AccountStatus.Active)
                {
                    _session.SetString("loggedInUser", JsonConvert.SerializeObject(_mapper.Map<UserModel>(existUser)));
                    return HttpStatusCode.Accepted;
                }
                else
                {
                    return HttpStatusCode.Unauthorized;
                }
            }
            return  HttpStatusCode.NoContent;
        }
    }
}
