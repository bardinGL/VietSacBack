using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.Repository;
using VietSacBackend._4.Core.Model.Order;
using AutoMapper;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._2.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public ResponseOrderModel CreateOrder(RequestOrderModel requestOrder)
        {
            var orderEntity = _mapper.Map<OrderEntity>(requestOrder);
            var cartEntities = _mapper.Map<List<CartEntity>>(requestOrder.Carts);
            var isSuccess = _orderRepository.CreateOrder(orderEntity, cartEntities);
            if (!isSuccess) throw new Exception("Order creation failed");

            return _mapper.Map<ResponseOrderModel>(orderEntity);
        }

        public ResponseOrderModel GetOrderById(string id)
        {
            var order = _orderRepository.GetById(id);
            return _mapper.Map<ResponseOrderModel>(order);
        }

        public IEnumerable<ResponseOrderModel> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<ResponseOrderModel>>(orders);
        }

        public ResponseOrderModel UpdateOrder(string id, RequestOrderModel requestOrder)
        {
            var orderEntity = _orderRepository.GetById(id);
            if (orderEntity == null) throw new Exception("Order not found");

            _mapper.Map(requestOrder, orderEntity);
            _orderRepository.Update(orderEntity);
            return _mapper.Map<ResponseOrderModel>(orderEntity);
        }

        public bool DeleteOrder(string id)
        {
            var orderEntity = _orderRepository.GetById(id);
            if (orderEntity == null) return false;

            _orderRepository.Delete(orderEntity);
            return true;
        }
    }
}
