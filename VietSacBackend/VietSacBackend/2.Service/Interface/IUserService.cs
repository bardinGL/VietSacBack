using VietSacBackend._4.Core.Model;
using VietSacBackend._4.Core.Model.User;

namespace VietSacBackend._2.Service.Interface
{
    public interface IUserService
    {
        public ResponseModel GetAll();
        public ResponseModel GetSingle(string id);
        public ResponseModel UpdateUser(string id, RequestUserModel requestUserModel);
        public ResponseModel DeleteUser(string id);
    }
}
