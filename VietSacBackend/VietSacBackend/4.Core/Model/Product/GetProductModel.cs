using System.Collections.Generic;

namespace VietSacBackend._4.Core.Model.Product
{
    public class GetProductModel
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int? Discount { get; set; }
        public string Image { get; set; }
    }

    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public List<T> Data { get; set; }
        public string MessageError { get; set; }
    }
}
