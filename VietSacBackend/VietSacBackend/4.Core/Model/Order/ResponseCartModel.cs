    namespace VietSacBackend._4.Core.Model.Order
    {
        public class ResponseCartModel { 
            public string Id { get; set; }
            public string UserId { get; set; }
            public string ProductId { get; set; }
            public decimal? Price { get; set; }
            public decimal? Quantity { get; set; }
        }
    }
