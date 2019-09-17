using NexusSaaS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Models
{
    public class RoleUserModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UserEntity UserEntity { get; set; }
        public Role Role { get; set; }
        public DateTime GrantDate { get; set; }
        public RoleUserStatus Status { get; set; }
    }

    public enum RoleUserStatus
    {
        Active = 1,
        Deactive = 0
    }
}
