﻿using System;

namespace NexusSaaS.Entity
{
    public class RoleUser
    {
        public RoleUser()
        {
            this.Status = RoleUserStatus.Active;
            this.GrantDate = DateTime.Now;
        }

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
