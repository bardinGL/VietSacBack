using VietSacBackend._4.Core.Model.Order;

namespace VietSacBackend._2.Service.Interface
{
    public interface ICartService
    {
        ResponseCartModel AddToCart(RequestCartModel requestCart);
        ResponseCartModel GetCartById(string id);
        IEnumerable<ResponseCartModel> GetAllCarts();
        ResponseCartModel UpdateCart(string id, RequestCartModel requestCart);
        bool RemoveFromCart(string id);
        List<ResponseCartModel> GetUserCart(string userId);
    }
}
