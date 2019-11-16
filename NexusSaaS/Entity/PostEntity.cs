using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Entity
{
    public class PostEntity
    {
        public PostEntity(){
            this.Date = DateTime.Now;
        }

        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public UserEntity User { get; set; }
        public List<Comment> Comments { get; set; }
        public List<PostCategory> PostCategories { get; set; }
    }
}
