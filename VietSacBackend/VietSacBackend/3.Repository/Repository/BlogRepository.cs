using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._3.Repository.Repository
{
    public interface IBlogRepository : IGenericRepository<BlogEntity>
    {
    }

    public class BlogRepository : GenericRepository<BlogEntity>, IBlogRepository
    {

    }
}
