using System.ComponentModel.DataAnnotations.Schema;

namespace VietSacBackend._3.Repository.Data
{
    public class ProductEntity : Entity
    {
        public string category_id { get; set; }

        public string? image { get; set; }

        public string? name { get; set; }

        public string? description { get; set; }


        [Column(TypeName = "decimal(38,4)")]
        public decimal? price { get; set; }

        public decimal? quantity { get; set; }

        public int? discount { get; set; }

        [ForeignKey(nameof(category_id))]
        public CategoryEntity Category { get; set; }

        public virtual ICollection<CartEntity> Carts { get; set; }
    }
}
