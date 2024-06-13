using System;
using System.Collections.Generic;
using VietSacBackend._4.Core.EnumCore;

namespace VietSacBackend._4.Core.Model.Order
{
    public class ResponseOrderModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string? ShippingMethodId { get; set; }
        public string? PaymentMethodId { get; set; }
        public decimal? OrderTotal { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public List<ResponseCartModel> Carts { get; set; }
    }
}
