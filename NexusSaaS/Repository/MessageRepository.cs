using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NexusSaaS.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public MessageRepository(NexusSaaSDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpStatusCode Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Messages.Find(id);
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

        public MessageModel GetById(int id)
        {
            var obj = _context.Messages
                .ProjectTo<MessageModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault(m => m.Id == id);

            if (obj != null)
            {
                return obj;
            }
            return null;
        }

        public MessageModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageModel> List()
        {
            var list = _context.Messages
                .ProjectTo<MessageModel>(_mapper.ConfigurationProvider)
                .ToList();
            if (list != null || list.Count() > 0)
            {
                return list;
            }
            return null;
        }

        public HttpStatusCode Save(MessageModel objModel)
        {
            if (objModel != null)
            {
                try
                {
                    if (_session.GetString("loggedInUser") != null)
                    {
                        objModel.UserEntity = JsonConvert.DeserializeObject<UserEntity>(_session.GetString("loggedInUser"));
                    }
                    var objEntity = _mapper.Map<MessageEntity>(objModel);
                    _context.Messages.Add(objEntity);
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

        public HttpStatusCode Update(MessageModel objModel)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (objModel != null)
                    {
                        var objEntity = _mapper.Map<MessageEntity>(objModel);
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
