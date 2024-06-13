using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VietSacBackend._4.Core.EnumCore;

namespace VietSacBackend._3.Repository.Data
{
    [Table("Order")]
    public class OrderEntity : Entity
    {
        public string user_id { get; set; }
        public DateTimeOffset order_date { get; set; }
        public string? shippingMenthod_id { get; set; }
        public string? paymentMenthod_id { get; set; }
        public decimal? orderTotal { get; set; }
        public OrderStatus? orderStatus { get; set; }

        [ForeignKey(nameof(paymentMenthod_id))]
        public PaymentMenthodEntity paymentMenthod { get; set; }

        [ForeignKey(nameof(shippingMenthod_id))]
        public ShippingMethodEntity shippingMenthod { get; set; }

        [ForeignKey(nameof(user_id))]
        public UserEntity User { get; set; }

        public virtual ICollection<CartEntity> Carts { get; set; }
    }
}
