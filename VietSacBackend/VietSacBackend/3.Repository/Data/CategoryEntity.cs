namespace VietSacBackend._3.Repository.Data
{
    public class CategoryEntity : Entity
    {
        public string category_name { get; set; }
        public string Brand { get; set; }
        public string Purpose { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
