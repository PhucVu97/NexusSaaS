using NexusSaaS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public int CommentCount { get; set; }
        public List<string> CategorieName { get; set; }
        public int[] CategorieIds { get; set; }
    }
}
