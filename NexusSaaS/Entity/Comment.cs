using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Entity
{
    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public UserEntity User { get; set; }
        public PostEntity Post { get; set; }
    }
}
