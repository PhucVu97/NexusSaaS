using NexusSaaS.Entity;
using System;
using System.Collections.Generic;

namespace NexusSaaS.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AccountStatus Status { get; set; }
        public virtual List<MessageEntity> MessageEntitys { get; set; }
        public virtual List<RoleUser> RoleUsers { get; set; }


        public int MessagesCount { get; set; }
        public int RolesCount { get; set; }
    }

    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }
}
