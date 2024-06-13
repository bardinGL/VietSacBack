using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._3.Repository.Repository
{
    public interface IOrderRepository : IGenericRepository<OrderEntity>
    {
        bool CreateOrder(OrderEntity order, List<CartEntity> carts);
    }

    public class OrderRepository : GenericRepository<OrderEntity>, IOrderRepository
    {

        public bool CreateOrder(OrderEntity order, List<CartEntity> carts)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.orderEntities.Add(order);
                foreach (var cart in carts)
                {
                    _context.cartEntities.Update(cart);
                }
                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
