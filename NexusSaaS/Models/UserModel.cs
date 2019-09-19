using NexusSaaS.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;


namespace NexusSaaS.Models
{
    public class UserModel
    {
        public UserModel()
        {
            CreatedAt = DateTime.Today;
            UpdatedAt = DateTime.Today;
            Salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(this.Salt);
            }
            Status = AccountStatus.Active;
        }

        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AccountStatus Status { get; set; }
        public List<MessageEntity> MessageEntitys { get; set; }
        public List<RoleUser> RoleUsers { get; set; }

        [Required(ErrorMessage = "Please select at least role")]
        public int[] RoleIds { get; set; }
        public List<string> RoleNames { get; set; }
        public int MessagesCount { get; set; }
        public int RolesCount { get; set; }
    }

    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }
}
