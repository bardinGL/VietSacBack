using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._3.Repository.Repository
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
    }

    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
    }
}
