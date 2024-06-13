using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._3.Repository.Repository
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {

    }

    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {

    }
}
