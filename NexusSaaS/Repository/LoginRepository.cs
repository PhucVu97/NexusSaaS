using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using NexusSaaS.Ultil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;
        private readonly StringUltil _stringUltil;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public LoginRepository(NexusSaaSDbContext context, IMapper mapper, StringUltil stringUltil, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _stringUltil = stringUltil;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login(UserModel user)
        {
            var existUser = _context.Users
               .Where(a => a.Status != Entity.AccountStatus.Deactive)
               .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
               .SingleOrDefault(u => u.Email == user.Email);

            if (existUser != null)
            {
                user.Password = _stringUltil.EncryptPassword(user.Password, existUser.Salt);
                var roles = "";
                if (existUser.Password == user.Password)
                {
                    var id = existUser.UserId;
                    _session.SetString("loggedInUser", JsonConvert.SerializeObject(_mapper.Map<UserModel>(existUser)));
                }
                else
                {
                    return new UnauthorizedResult();
                }
            }
            return new NoContentResult();
        }
    }
}
