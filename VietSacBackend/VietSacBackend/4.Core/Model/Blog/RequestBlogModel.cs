using System.ComponentModel.DataAnnotations;

namespace VietSacBackend._4.Core.Model.Blog
{
    public class RequestBlogModel
    {
        [Required]
        public string Title { get; set; } 
        [Required]
        public string PictureLink { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
