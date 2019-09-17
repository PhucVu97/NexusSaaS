using AutoMapper;
using AutoMapper.QueryableExtensions;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Repository
{
    public class RoleUserRepository : IRoleUser
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;

        public RoleUserRepository(NexusSaaSDbContext context, IMapper mapper)
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
            throw new NotImplementedException();
        }

        public RoleUserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RoleUserModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleUserModel> List()
        {
            throw new NotImplementedException();
        }

        public void Save(RoleUserModel objModel)
        {
            if (objModel != null)
            {
                var objEntity = _mapper.Map<RoleUser>(objModel);
                _context.Add(objEntity);
                _context.SaveChanges();
            }
        }

        public void Update(RoleUserModel objModel)
        {
            throw new NotImplementedException();
        }
    }
}
