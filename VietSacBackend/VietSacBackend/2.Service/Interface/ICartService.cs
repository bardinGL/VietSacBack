using VietSacBackend._4.Core.Model.Order;
using VietSacBackend._4.Core.Model;
using System.Collections.Generic;

namespace VietSacBackend._2.Service.Interface
{
    public interface ICartService
    {
        ResponseModel AddToCart(string userId, RequestCartModel requestCart);
        ResponseCartModel GetCartById(string id);
        IEnumerable<ResponseCartModel> GetAllCarts();
        ResponseModel UpdateCart(string id, RequestCartModel requestCart);
        bool RemoveFromCart(string id);
        List<ResponseCartModel> GetUserCart(string userId);
    }
}
