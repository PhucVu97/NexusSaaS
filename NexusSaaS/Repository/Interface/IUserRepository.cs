using NexusSaaS.Entity;
using NexusSaaS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NexusSaaS.Repository.Interface
{
    public interface IUserRepository : IGenericRepository<UserEntity, UserModel>
    {
        UserModel GetByEmail(string email);
        HttpStatusCode Login(LoginViewModel loginUser);
        HttpStatusCode Logout();
        HttpStatusCode ResetPasswordUrl(string email);
        HttpStatusCode ResetPassword(ResetPasswordModel resetPassword);
    }
}
