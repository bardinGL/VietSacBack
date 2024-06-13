namespace VietSacBackend._4.Core.Model.Order
{
    public class RequestCartModel
    {
        public string ProductId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
    }
}
