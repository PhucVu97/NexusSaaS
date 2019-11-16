using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Entity
{
    public class PostCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public PostEntity PostEntity { get; set; }
    }
}
