using AutoMapper;
using System;
using System.Linq;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model.Order;
using VietSacBackend._4.Core.Model;
using VietSacBackend._4.Core.EnumCore;
using Microsoft.EntityFrameworkCore;
using VietSacBackend._3.Repository.Repository;

namespace VietSacBackend._2.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly VietSacContext _context;

        public OrderService(
            IOrderRepository orderRepository,
            ICartRepository cartRepository,
            IMapper mapper,
            VietSacContext context)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
            _context = context;
        }

        public ResponseModel CreateOrderFromCart(string userId)
        {
            // Fetch cart items for the user
            var cartItems = _cartRepository.Get(c => c.user_id == userId).ToList();
            if (cartItems == null || !cartItems.Any())
            {
                return new ResponseModel
                {
                    MessageError = "Cart is empty",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Calculate total price
            var totalPrice = cartItems.Sum(item => item.price ?? 0);

            // Create the order
            var orderEntity = new OrderEntity
            {
                user_id = userId,
                order_date = DateTimeOffset.UtcNow,
                orderTotal = totalPrice,
                orderStatus = OrderStatus.DaXacNhan,
                //Carts = cartItems // Xóa cái này đi 
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Add order to the repository
                    _orderRepository.Create(orderEntity);

                    // Update the cart items with the order ID
                    foreach (var item in cartItems)
                    {
                        item.order_id = orderEntity.Id;
                        _cartRepository.Update(item);
                    }

                    foreach (var item in cartItems)
                    {
                        _cartRepository.Delete(item);
                    }

                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    var innerExceptionMessage = ex.InnerException?.Message ?? ex.Message;

                    return new ResponseModel
                    {
                        MessageError = $"An error occurred while saving the entity changes. Details: {innerExceptionMessage}",
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }
            }

            return new ResponseModel
            {
                Data = _mapper.Map<ResponseOrderModel>(orderEntity),
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
