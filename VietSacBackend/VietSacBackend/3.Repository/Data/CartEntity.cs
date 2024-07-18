using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VietSacBackend._3.Repository.Data
{
    [Table("Cart")]
    public class CartEntity : Entity
    {
        public string product_id { get; set; }
        public string user_id { get; set; }

        [AllowNull]
        public string? order_id { get; set; }

        [Column(TypeName = "decimal(38,4)")]
        public decimal? price { get; set; }

        [Column(TypeName = "decimal(38,4)")]
        public decimal? quantity { get; set; }

        [ForeignKey(nameof(order_id))]
        public virtual OrderEntity Order { get; set; }

        [ForeignKey(nameof(product_id))]
        public ProductEntity Product { get; set; }

        [ForeignKey(nameof(user_id))]
        public UserEntity User { get; set; }

        public string category_id { get; set; } // New property for CategoryId
        public string product_name { get; set; } // New property for Product Name
        public string product_description { get; set; } // New property for Product Description
        public string product_image { get; set; } // New property for Product Image
        public decimal product_price { get; set; } // New property for Original Product Price
        public int? product_discount { get; set; } // New property for Product Discount
    }
}
