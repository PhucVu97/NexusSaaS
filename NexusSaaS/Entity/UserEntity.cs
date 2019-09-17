using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace NexusSaaS.Entity
{
    [Table("users")]
    public class UserEntity
    {
        public UserEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Today;
            this.UpdatedAt = DateTime.Today;
            this.Status = AccountStatus.Active;
            this.Salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(this.Salt);
            }
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AccountStatus Status { get; set; }

        public virtual List<MessageEntity> MessageEntitys { get; set; }
        public virtual List<RoleUser> RoleUsers { get; set; }
    }

    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }
}
