using VietSacBackend._4.Core.Model.Role;
using VietSacBackend._4.Core.Model;

namespace VietSacBackend._2.Service.Interface
{
    public interface IRoleService
    {
        public ResponseModel CreateRole(RequestRoleModel entity);
        public ResponseModel GetAll();
        public ResponseModel GetRoleID(string id);
        public ResponseModel UpdateRole(string id, RequestRoleModel requestRoleModel);
        public ResponseModel DeleteRole(string id);
    }
}
