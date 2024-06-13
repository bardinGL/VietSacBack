using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._3.Repository.Repository
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
    }

    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
    }
}
