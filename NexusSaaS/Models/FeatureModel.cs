using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NexusSaaS.Models
{
    public class FeatureModel
    {

        #region property theo entity
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        public IFormFile Img { get; set; }
        #endregion

        #region property rieng cua model
        public string ImgUrl { get; set; }
        #endregion
    }
}
