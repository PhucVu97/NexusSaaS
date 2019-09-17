using NexusSaaS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public RoleStatus Status { get; set; }
        public virtual List<RoleUser> RoleUsers { get; set; }


        public int UserCount { get; set; }
    }

    public enum RoleStatus
    {
        Active = 1,
        Deactive = 0
    }
}
