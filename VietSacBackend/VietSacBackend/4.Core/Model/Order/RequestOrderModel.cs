using System;
using System.Collections.Generic;

namespace VietSacBackend._4.Core.Model.Order
{
    public class RequestOrderModel
    {
        public string UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string? ShippingMethodId { get; set; }
        public string? PaymentMethodId { get; set; }
        public decimal? OrderTotal { get; set; }
        public List<RequestCartModel> Carts { get; set; }
    }
}
