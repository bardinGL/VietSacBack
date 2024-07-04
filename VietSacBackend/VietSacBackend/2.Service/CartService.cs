using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model.Order;
using VietSacBackend._4.Core.Model;
using VietSacBackend._3.Repository.Repository;

namespace VietSacBackend._2.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public CartService(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IGenericRepository<UserEntity> userRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ResponseModel AddToCart(string userId, RequestCartModel requestCart)
        {
            // Validate user
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return new ResponseModel
                {
                    MessageError = "User not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Validate product
            var product = _productRepository.GetById(requestCart.ProductId);
            if (product == null)
            {
                return new ResponseModel
                {
                    MessageError = "Product not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Calculate total price
            var totalPrice = product.price * requestCart.Quantity;

            // Check if the item already exists in the cart
            var existingCartItem = _cartRepository.Get(c => c.user_id == userId && c.product_id == requestCart.ProductId).FirstOrDefault();
            if (existingCartItem != null)
            {
                // Update the quantity and total price if the item already exists
                existingCartItem.quantity += requestCart.Quantity;
                existingCartItem.price += totalPrice;
                _cartRepository.Update(existingCartItem);
                return new ResponseModel
                {
                    Data = _mapper.Map<ResponseCartModel>(existingCartItem),
                    StatusCode = StatusCodes.Status200OK
                };
            }

            // Add new item to the cart
            var cartEntity = _mapper.Map<CartEntity>(requestCart);
            cartEntity.user_id = userId; // Set the UserId
            cartEntity.price = totalPrice; // Set total price
            _cartRepository.Create(cartEntity);
            return new ResponseModel
            {
                Data = _mapper.Map<ResponseCartModel>(cartEntity),
                StatusCode = StatusCodes.Status201Created
            };
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

        public ResponseModel UpdateCart(string id, RequestCartModel requestCart)
        {
            var cartEntity = _cartRepository.GetById(id);
            if (cartEntity == null) throw new Exception("Cart not found");

            _mapper.Map(requestCart, cartEntity);
            _cartRepository.Update(cartEntity);
            return new ResponseModel
            {
                Data = _mapper.Map<ResponseCartModel>(cartEntity),
                StatusCode = StatusCodes.Status200OK
            };
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
