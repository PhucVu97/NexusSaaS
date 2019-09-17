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
    public class MessageRepository : IMessageRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;
        public MessageRepository(NexusSaaSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
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

        public void Save(MessageModel objModel)
        {
            if (objModel != null)
            {
                var objEntity = _mapper.Map<MessageEntity>(objModel);
                _context.Messages.Add(objEntity);
                _context.SaveChanges();
            }
        }

        public void Update(MessageModel objModel)
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
