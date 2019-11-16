using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly MailUltil _mailUltil;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelper urlHepler;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UserRepository(NexusSaaSDbContext context, IMapper mapper, StringUltil stringUltil, IHttpContextAccessor httpContextAccessor, IUrlHelper urlHepler, MailUltil mailUltil)
        {
            _context = context;
            _mapper = mapper;
            _stringUltil = stringUltil;
            _httpContextAccessor = httpContextAccessor;
            this.urlHepler = urlHepler;
            _mailUltil = mailUltil;
        }

        public HttpStatusCode Delete(string id)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Delete(int id)
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
                        foreach (var cookie in _httpContextAccessor.HttpContext.Request.Cookies.Keys)
                        {
                            _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie);
                        }
                        _httpContextAccessor.HttpContext.Session.Clear();
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

        public HttpStatusCode Save(UserModel objModel)
        {
            if (objModel != null)
            {
                var existUser = _context.Users.SingleOrDefault(u => u.Email == objModel.Email);
                if(existUser != null)
                {
                    return HttpStatusCode.Conflict;
                }
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
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public HttpStatusCode Update(UserModel objModel)
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

        public HttpStatusCode Login(LoginViewModel loginUser)
        {
            var existUser = _context.Users
               .Where(a => a.Status != Entity.AccountStatus.Deactive)
               .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
               .SingleOrDefault(u => u.Email == loginUser.Email);

            if (existUser != null)
            {
                loginUser.Password = _stringUltil.EncryptPassword(loginUser.Password, existUser.Salt);
                if (existUser.Password == loginUser.Password && existUser.Status == Models.AccountStatus.Active)
                {
                    foreach (var cookie in _httpContextAccessor.HttpContext.Request.Cookies.Keys)
                    {
                        _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie);
                    }
                    _httpContextAccessor.HttpContext.Session.Clear();

                    _session.SetString("loggedInUser", JsonConvert.SerializeObject(_mapper.Map<UserModel>(existUser)));
                    if(loginUser.RememberMe != null)
                    {
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("loggedInUser", JsonConvert.SerializeObject(_mapper.Map<UserModel>(existUser)));
                    }
                    return HttpStatusCode.Accepted;
                }
                else
                {
                    return HttpStatusCode.Unauthorized;
                }
            }
            return  HttpStatusCode.NoContent;
        }

        public HttpStatusCode Logout()
        {
            foreach (var cookie in _httpContextAccessor.HttpContext.Request.Cookies.Keys)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie);
            }
            _httpContextAccessor.HttpContext.Session.Clear();
            return HttpStatusCode.OK;
        }

        public HttpStatusCode ResetPasswordUrl(string email)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            if(user != null)
            {
                try
                {
                    var credential = new Credential(user.UserId);
                    _context.Add(credential);
                    _context.SaveChanges();
                    string scheme = _httpContextAccessor.HttpContext.Request.Scheme;
                    var resetUrl = urlHepler.Action(action: "ResetPassword", controller: "Login", values: new { credential.AccessToken }, protocol: scheme);
                    _mailUltil.SendEmail("Reset Password", resetUrl, user.Email, user.Name);
                    return HttpStatusCode.OK;
                }
                catch
                {
                    return HttpStatusCode.InternalServerError;
                }
            }
            return HttpStatusCode.NotFound;
        }

        public HttpStatusCode ResetPassword(ResetPasswordModel resetPassword)
        {
            if(resetPassword != null)
            {
                var credential = _context.Credentials.SingleOrDefault(c => c.AccessToken == resetPassword.Token);
                if (credential.IsValid())
                {
                    var user = GetById(credential.OwnerId);
                    user.Password = _stringUltil.EncryptPassword(resetPassword.Password, user.Salt);
                    return HttpStatusCode.OK;
                }
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.BadRequest;
        }
    }
}
