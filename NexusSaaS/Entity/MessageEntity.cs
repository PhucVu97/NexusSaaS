﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Entity
{
    [Table("message")]
    public class MessageEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
