using System.ComponentModel.DataAnnotations;

namespace VietSacBackend._4.Core.Model.Product
{
    public class RequestProductModel
    {
        [Required(ErrorMessage = "Category ID is required")]
        public string category_id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public int? Discount { get; set; }
        public string Image { get; set; }
    }
}
