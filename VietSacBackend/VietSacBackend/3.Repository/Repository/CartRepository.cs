using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._3.Repository.Repository
{
    public interface ICartRepository : IGenericRepository<CartEntity>
    {
    }

    public class CartRepository : GenericRepository<CartEntity>, ICartRepository
    {

    }
}
