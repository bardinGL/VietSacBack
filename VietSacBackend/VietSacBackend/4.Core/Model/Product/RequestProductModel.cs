namespace VietSacBackend._4.Core.Model.Product
{
    public class RequestProductModel
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int? Discount { get; set; }
    }
}
