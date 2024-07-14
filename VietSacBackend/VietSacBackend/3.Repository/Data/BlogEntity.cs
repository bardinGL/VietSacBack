using System.ComponentModel.DataAnnotations;

namespace VietSacBackend._3.Repository.Data
{
    public class BlogEntity : Entity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string PictureLink { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
