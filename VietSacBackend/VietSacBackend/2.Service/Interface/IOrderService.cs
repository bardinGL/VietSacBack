using VietSacBackend._4.Core.Model.Order;
using VietSacBackend._4.Core.Model;

namespace VietSacBackend._2.Service.Interface
{
    public interface IOrderService
    {
        ResponseModel CreateOrderFromCart(string userId);
    }
}
