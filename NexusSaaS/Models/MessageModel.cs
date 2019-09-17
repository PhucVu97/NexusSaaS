using NexusSaaS.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Models
{
    public class MessageModel
    {
        #region property theo entity
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        public UserEntity UserEntity { get; set; }
        #endregion

        #region property rieng cua model
        public string UserEntityId { get; set; }
        public string UserEntityName { get; set; }
        public string UserEntityEmail { get; set; }
        #endregion
    }
}
