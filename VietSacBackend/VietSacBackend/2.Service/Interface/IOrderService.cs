using VietSacBackend._4.Core.Model.Order;

namespace VietSacBackend._2.Service.Interface
{
    public interface IOrderService
    {
        ResponseOrderModel CreateOrder(RequestOrderModel requestOrder);
        ResponseOrderModel GetOrderById(string id);
        IEnumerable<ResponseOrderModel> GetAllOrders();
        ResponseOrderModel UpdateOrder(string id, RequestOrderModel requestOrder);
        bool DeleteOrder(string id);
    }
}
