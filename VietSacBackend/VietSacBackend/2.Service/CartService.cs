using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.Repository;
using VietSacBackend._4.Core.Model.Order;
using AutoMapper;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._2.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public ResponseCartModel AddToCart(RequestCartModel requestCart)
        {
            var cartEntity = _mapper.Map<CartEntity>(requestCart);
            _cartRepository.Create(cartEntity);
            return _mapper.Map<ResponseCartModel>(cartEntity);
        }

        public ResponseCartModel GetCartById(string id)
        {
            var cart = _cartRepository.GetById(id);
            return _mapper.Map<ResponseCartModel>(cart);
        }

        public IEnumerable<ResponseCartModel> GetAllCarts()
        {
            var carts = _cartRepository.GetAll();
            return _mapper.Map<IEnumerable<ResponseCartModel>>(carts);
        }

        public ResponseCartModel UpdateCart(string id, RequestCartModel requestCart)
        {
            var cartEntity = _cartRepository.GetById(id);
            if (cartEntity == null) throw new Exception("Cart not found");

            _mapper.Map(requestCart, cartEntity);
            _cartRepository.Update(cartEntity);
            return _mapper.Map<ResponseCartModel>(cartEntity);
        }

        public bool RemoveFromCart(string id)
        {
            var cartEntity = _cartRepository.GetById(id);
            if (cartEntity == null) return false;

            _cartRepository.Delete(cartEntity);
            return true;
        }

        public List<ResponseCartModel> GetUserCart(string userId) 
        {
            var cartEntities = _cartRepository.Get(c => c.user_id == userId).ToList();
            return _mapper.Map<List<ResponseCartModel>>(cartEntities);
        }
    }
}
