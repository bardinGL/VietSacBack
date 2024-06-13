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
    }
}
